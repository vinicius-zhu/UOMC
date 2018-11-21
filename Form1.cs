using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Ultima;

namespace UOMC
{
    public partial class Form1 : Form
    {
        private Thread thread;
        private List<Thread> threads;
        private TileMatrix tileMatrix;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (thread != null && thread.ThreadState == ThreadState.Running)
            {
                try
                {
                    thread.Abort();
                    foreach (Thread t in threads)
                    {
                        t.Abort();
                    }
                }
                catch
                {
                }
            }
            else
            {
                thread = new Thread(threadstart);
                thread.Start();
            }
        }

        private void threadstart()
        {
            tileMatrix = new TileMatrix(0, 0, 6144, 4096);
            threads = new List<Thread>(Environment.ProcessorCount);
            for (int i = 0; i < Environment.ProcessorCount; i++)
            {
                threads.Add(new Thread(threadstep));
                threads[i].Start(i * tileMatrix.Width / Environment.ProcessorCount);
            }
        }

        private void threadstep(object o)
        {
            for (int i = 0; i < tileMatrix.Height; i++)
            {
                for (int j = (int)o; j < (int)o + tileMatrix.Width / Environment.ProcessorCount; j++)
                {
                    for (int k = -64; k < 64; k++)
                    {

                    }
                }
            }
        }
    }
}
