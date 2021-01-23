    Process myProcess = new Process();
            try
            {   
                ProcessStartInfo procStartInfo = new ProcessStartInfo("cmd.exe", yourarguments);
                procStartInfo.RedirectStandardOutput = true;
                procStartInfo.RedirectStandardError = true;
                procStartInfo.UseShellExecute = false;
                Process proc = new Process();
                proc.StartInfo = procStartInfo;
                myProcess.Start();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
