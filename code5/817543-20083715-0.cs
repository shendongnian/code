    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            Thread backgroundWorker = null;
            int startingThreadState = 0;
    
            private void button1_Click(object sender, EventArgs e)
            {
                startingThreadState += 100;
                if (backgroundWorker == null || !backgroundWorker.IsAlive)
                {
                    InitThread();
                    backgroundWorker.Start(startingThreadState);
                }
                else
                {
                    backgroundWorker.Abort(startingThreadState);
                }
            }
    
            private void InitThread()
            {
                backgroundWorker = new Thread(new ParameterizedThreadStart((state)=>
                    {
                        while (true)
                        {
                            try
                            {
                                CodeToRunInsideBackgroundThread(state);
                                break;//while(true)
                            }
                            catch (ThreadAbortException ex)
                            {
                                System.Threading.Thread.ResetAbort();
                                state = startingThreadState;// state available in ex.Data here?
                            }
                        }
                    }));
                backgroundWorker.IsBackground = true;
            }
    
            private void CodeToRunInsideBackgroundThread(object state)
            {
                for (int i = (int)state; i < (int)state + 3; i++)
                {
                    System.Threading.Thread.Sleep(1000);
                    this.Invoke(
                        new Action(() =>
                        {
                            label1.Text = i.ToString();
                        })
                    );
                }
            }
        }
    }
