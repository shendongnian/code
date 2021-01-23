            // start IIS
            bool systray = Debugger.IsAttached;
            ProcessStartInfo psi = new ProcessStartInfo(iisExecutable, String.Format("/config:\"{0}\" /site:Ecm2.Web /trace:info /systray:{1}", configFile, systray));
            psi.UseShellExecute = false;
            psi.RedirectStandardInput = false;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;
            psi.CreateNoWindow = true;
            if (this.iisProcess != null) throw new NotSupportedException("Multiple starts not supported");
            this.iisProcess = new Process();
            this.iisProcess.StartInfo = psi;
            this.iisProcess.ErrorDataReceived += OnErrorDataReceived;
            this.iisProcess.OutputDataReceived += OnOutputDataReceived;
            this.iisProcess.Start();
            this.iisProcess.BeginErrorReadLine();
            this.iisProcess.BeginOutputReadLine();
