    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Windows.Forms;
    
    namespace ThreadTest2
    {
        public partial class Form1 : Form
        {
            Thread mainThread = null;
    
            public Form1()
            {
                InitializeComponent();
    
                mainThread = Thread.CurrentThread;
    
                Thread myThread = new Thread(FadeOverlayText);
                myThread.Start();
            }
    
    
            private void FadeOverlayText()
            {
    
                while (mainThread.IsAlive)
                {
                    ClearLabelText();
    
                    Thread.Sleep(1000);
                }
            }
    
            public void ClearLabelText()
            {
                if (StatusText.InvokeRequired)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        StatusText.Text = "Something should happen";
                    });
                }
                else
                {
                    StatusText.Text = "Something should happen";
                }
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                StatusText.Text = "It works!";
            }
        }
    }
