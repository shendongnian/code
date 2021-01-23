        public void WatchboxWorker_RunProc(object sender, DoWorkEventArgs e)
        {
            string exeLoc = (string) e.Argument;
            string arg1 = exeLoc;
            string arg2 = "";
            ProcessStartInfo pStartInfo = new ProcessStartInfo();
            pStartInfo.FileName = exeLoc;
            pStartInfo.Arguments = string.Format("\"{0}\" \"{1}\"", arg1, arg2);
            
            pStartInfo.WorkingDirectory = Path.GetDirectoryName(exeLoc);
            pStartInfo.CreateNoWindow = true;
            pStartInfo.UseShellExecute = false;
            
            pStartInfo.RedirectStandardInput = true;
            pStartInfo.RedirectStandardOutput = true;
            pStartInfo.RedirectStandardError = true;
            
            Process process1 = new Process();
            process1.EnableRaisingEvents = true;
            process1.OutputDataReceived += (s, e1) => this.wbWriteBox(e1.Data);
            process1.ErrorDataReceived += (s, e1) => this.wbWriteBox(e1.Data);
            process1.StartInfo = pStartInfo;
            process1.SynchronizingObject = rtbWatchbox;
            process1.Start();
            process1.BeginOutputReadLine();
            process1.BeginErrorReadLine();
            process1.StandardInput.Close();
            process1.WaitForExit();
            //wbResetEvent.Set();
        }
