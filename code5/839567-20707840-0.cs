            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "arp";
            startInfo.Arguments = "-g";
            startInfo.RedirectStandardOutput = true;
            startInfo.UseShellExecute = false;
            process.StartInfo = startInfo;
            
            process.Start();
            String strData = process.StandardOutput.ReadToEnd();
