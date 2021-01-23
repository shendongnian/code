            static string processCMD(string fileName, string arguments) 
            {
                StringBuilder output = new StringBuilder();
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.StartInfo.FileName = fileName;
                proc.StartInfo.Arguments = arguments;
                proc.UseShellExecute = false;
                proc.RedirectStandardOutput = true;
                proc.CreateNoWindow = true;
                proc.Start();
                while (!proc.StandardOutput.EndOfStream) {
                    output.Append(proc.StandardOutput.ReadLine());
                }
                proc.WaitForExit();
                return output.ToString();
            }
