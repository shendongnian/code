            // as there will not be an input stream so don't Redirect 
            p.StartInfo.RedirectStandardInput = false;
            // use a stringbuilder to capture everything
            var sb = new StringBuilder();
            // raise events on stdout and stderr and handle them
            p.EnableRaisingEvents = true;
            p.OutputDataReceived += (sender, args) => sb.AppendFormat("Out: {0}<br />",args.Data);
            p.ErrorDataReceived  += (sender, args) => sb.AppendFormat("Err: {0}<br />",args.Data);
            
            p.Start();
            
            // start consuming
            p.BeginOutputReadLine();
            p.BeginErrorReadLine();
            // wait for process to exit
            p.WaitForExit();
            p.Close();
            // obtain out stringbuilder value
            string message = sb.ToString();
            return message;
