            Process interactiveProcess = new Process();
            string processOutput = "";
            interactiveProcess.StartInfo.FileName = this.processPath;
            interactiveProcess.StartInfo.Arguments = commandLineParameters;
            interactiveProcess.StartInfo.UseShellExecute = false;
            interactiveProcess.StartInfo.CreateNoWindow = false;
            interactiveProcess.StartInfo.RedirectStandardInput = true;
            interactiveProcess.StartInfo.RedirectStandardError = true;
            interactiveProcess.Start();
            
            interactiveProcess.EnableRaisingEvents = true;
            interactiveProcess.ErrorDataReceived += new DataReceivedEventHandler((process, outputEventArgs) => processOutput += outputEventArgs.Data);
            
            interactiveProcess.BeginErrorReadLine();
