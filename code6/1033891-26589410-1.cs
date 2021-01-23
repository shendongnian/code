    ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.CreateNoWindow = false;
            startInfo.UseShellExecute = false;
            startInfo.FileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ffmpeg\\ffmpeg.exe");
            startInfo.Arguments = "-f dshow -i video=\"Front Camera\"";
            startInfo.RedirectStandardOutput = true;
            //startInfo.RedirectStandardError = true;
            Console.WriteLine(string.Format(
                "Executing \"{0}\" with arguments \"{1}\".\r\n", 
                startInfo.FileName, 
                startInfo.Arguments));
            try
            {
                using (Process process = Process.Start(startInfo))
            {
                while (!process.StandardOutput.EndOfStream)
                {
                    string line = process.StandardOutput.ReadLine();
                    Console.WriteLine(line);
                }
                process.WaitForExit();
            }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
