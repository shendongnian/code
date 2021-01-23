    ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.CreateNoWindow = false;
            startInfo.UseShellExecute = false;
            startInfo.FileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ffmpeg\\ffmpeg.exe");
            startInfo.Arguments = "-f dshow -i video=\"Front Camera\"";
            Console.WriteLine(string.Format(
                "Executing \"{0}\" with arguments \"{1}\".\r\n", 
                startInfo.FileName, 
                startInfo.Arguments));
            try
            {
                using (Process exeProcess = Process.Start(startInfo))
                {
                    exeProcess.WaitForExit();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
