    using Microsoft.Win32;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    
    
    namespace ControlPanel
    {
        /// <summary>
        /// Interaction logic for ControlPanelFinal.xaml
        /// </summary>
        public partial class ControlPanelFinal : Window
        {
            private readonly BackgroundWorker _bw = new BackgroundWorker();
            public ControlPanelFinal()
            {
                InitializeComponent();
                SilverLightInstall();
                _bw.DoWork += _bw_DoWork;
                _bw.RunWorkerCompleted += _bw_RunWorkerCompleted;
                _bw.ProgressChanged += _bw_ProgressChanged;
               // _bw.WorkerReportsProgress = true;
            }
    
            void _bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
            {
                progressbar1.Value = e.ProgressPercentage;
            }
    
            void _bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
            {
                if ((e.Cancelled == true))
                {
                    this.textblock1.Text = "Completed";
                }
                else if (!(e.Error == null))
                {
                    this.textblock1.Text = ("Error :" + e.Error.Message);
                }
                else
                {
                    progressbar1.Maximum = 100;
                    progressbar1.Minimum = 1;
                    progressbar1.Value = progressbar1.Maximum;
                    textblock1.Text = "Completed";
                }
    
            }
    
            void _bw_DoWork(object sender, DoWorkEventArgs e)
            {
                for (int i = 0; i <= 100; i++)
                {
                    (sender as BackgroundWorker).ReportProgress(i);
                    Thread.Sleep(100);
    
                }
                string filepath = Path.Combine(Path.GetTempPath(), "Silverlight.exe");
                Process p = new Process();
                p.StartInfo.FileName = filepath;
                p.StartInfo.Arguments = string.Format(" /q  /i \"{0}\" ALLUSERS=1", filepath);
                p.StartInfo.Verb = "runas";
                p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.UseShellExecute = true;
                p.Start();
            
            }
            private void SilverLightInstall()
            {
                var Key1 = @"SOFTWARE\Microsoft";
                using (var regKey1 = Registry.LocalMachine.OpenSubKey(Key1))
                {
                    if (regKey1.GetSubKeyNames().Contains("Silverlight"))
                    {
                        textblock1.Text = "Install";
                        checkbox1.IsEnabled = false;
                    }
                    else
                    {
                        checkbox1.IsEnabled = true;
                        string filename = Path.Combine(Path.GetTempPath(), "Silverlight.exe");
                        using (StreamWriter sw = new StreamWriter(filename))
                        {
                            sw.WriteLine("Error");
                        }
                        WebClient client = new WebClient();
                        client.DownloadProgressChanged += client_DownloadProgressChanged;
                        client.DownloadFileCompleted += client_DownloadFileCompleted;
                        client.DownloadFileAsync(new Uri("http://download.microsoft.com/download/F/8/C/F8C0EACB-92D0-4722-9B18-965DD2A681E9/30514.00/Silverlight_x64.exe"), filename);
                    }
                }
    
            }
    
            void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
            {
                textblock2.Text = " Download Completed";
                btnInstall.IsEnabled = true;
    
            }
    
            void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
            {
                btnInstall.IsEnabled = false;
                double byteIn = double.Parse(e.BytesReceived.ToString());
                double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
                double percentage = byteIn / totalBytes * 100;
                textblock2.Text = "Download " + e.BytesReceived / 1024 + " Of " + e.TotalBytesToReceive / 1024;
                progressbar1.Value = int.Parse(Math.Truncate(percentage).ToString());
            }
            private void Button_Click_1(object sender, RoutedEventArgs e)
            {
                if (_bw.IsBusy == false)
                {
                    _bw.RunWorkerAsync();
                }
            }
        }
    }
         
