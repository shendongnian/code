            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = exe_path;
            // replace your arguments here
            psi.Arguments = string.Format(@" arguments ") 
            
            psi.CreateNoWindow = true;
            psi.ErrorDialog = true;
            psi.UseShellExecute = false;
            psi.WindowStyle = ProcessWindowStyle.Hidden;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardInput = false;
            psi.RedirectStandardError = true;
            Process exeProcess = Process.Start(psi);
            exeProcess.PriorityClass = ProcessPriorityClass.High;
            string outString = string.Empty;
            exeProcess.OutputDataReceived += (s, e) =>
            {
                outString += e.Data;
            };
            exeProcess.BeginOutputReadLine();
            string errString = exeProcess.StandardError.ReadToEnd();
            Trace.WriteLine(outString);
            Trace.TraceError(errString);
            exeProcess.WaitForExit();
            exeProcess.Close();
            exeProcess.Dispose();
