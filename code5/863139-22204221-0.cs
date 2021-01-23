    Task StartGPUMiner(object set)
        {
            MinerParams m = new MinerParams();
            m = (MinerParams)set;
            var tcs = new TaskCompletionSource<object>();
            Process p = new Process();
            ProcessStartInfo start = new System.Diagnostics.ProcessStartInfo();
            start.FileName = m.ApplicationPath + "\\cgminer\\cgminer.exe";
            start.Arguments = " -I " + m.GpuIntisity + " -T --scrypt -o " + m.sProtocol + m.ServerName + ":" +  m.ServerPort + " -u " + m.UserName + "." + m.WorkerName + " -p " + m.ThePassword + " " + m.GpuParams;
            start.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            start.RedirectStandardOutput = true;
            start.UseShellExecute = false;
            start.CreateNoWindow = true;
            var proc = Process.Start(start);
            proc.OutputDataReceived += (s, e) =>
            {
                try
                {
                    this.Invoke((Action)delegate
                    {
                        txtLog.Text += (e.Data + Environment.NewLine);
                    });
                }
                catch { }
            };
            try
            {
                proc.Exited += (s, e) => tcs.SetResult(null);
                proc.EnableRaisingEvents = true;
                proc.BeginOutputReadLine();
            }
            catch { }
                return tcs.Task;
    }
