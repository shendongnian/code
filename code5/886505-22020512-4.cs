    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Diagnostics;
    using System.Threading;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {  
            private Process p;
    
            public Form1()
            {
                InitializeComponent();
    
            }
    
            private void cmdPing_Click(object sender, EventArgs e)
            {
                p = new Process();
                startNewThread();
            }
    
            public void Log(string line)
            {
                txtOutput.Text += line + System.Environment.NewLine;
            }
    
            private void startNewThread()
            {
                Thread x = new Thread(new ThreadStart(Ping));
                x.IsBackground = true;
                x.Start();
            }
    
            private void Ping()
            {
                p.StartInfo.FileName = "ping.exe";
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.Arguments = txtAddress.Text;
                p.Start();
    
                while (p.StandardOutput.Peek() > -1)
                {
                    this.Invoke((MethodInvoker)delegate() { Log(p.StandardOutput.ReadLine()); });
                    p.StandardOutput.DiscardBufferedData();
                }
    
            }
    
        }
    }
