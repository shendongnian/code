        private void Button_Click(object sender, RoutedEventArgs e)
        {
             var proc = new Process();
             proc.StartInfo.FileName = @"E:\comm.bat";
             proc.StartInfo.UseShellExecute = false;
             proc.StartInfo.RedirectStandardOutput = true;
             proc.StartInfo.RedirectStandardError = true;
             proc.EnableRaisingEvents = true;
             proc.StartInfo.CreateNoWindow = true;
             proc.ErrorDataReceived += DataReceived;
             proc.OutputDataReceived += DataReceived;
             proc.Start();
             proc.BeginErrorReadLine();
             proc.BeginOutputReadLine();
             proc.WaitForExit();
        }
        void DataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data != null)
            {
                textBox1.Dispatcher.BeginInvoke((Action)(() => { UpdateText(e.Data); }), DispatcherPriority.Normal);
            }
        }
        public void UpdateText(String str)
        {
            textBox1.AppendText(str);
        }
