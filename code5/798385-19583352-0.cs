    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Diagnostics;
    
    namespace Test
    {
        class Program
        {
            static void Main(string[] args)
            {
                Process proc = new Process();
                proc.StartInfo.FileName = "test.bat";
                proc.StartInfo.UseShellExecute = false;
               proc.StartInfo.RedirectStandardOutput = true;
                proc.OutputDataReceived += proc_OutputDataReceived;
                proc.Start();
                proc.BeginOutputReadLine();
            }
        }
    
    
            void proc_OutputDataReceived(object sender, DataReceivedEventArgs e)
            {
                this.Dispatcher.Invoke((Action)(() =>
                            {
                                txtprogress.Text = txtprogress.Text + "\n" + e.Data;
                                txtprogress.ScrollToEnd();
                            }));
            }
    }
