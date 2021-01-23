                Process p = new Process(); //crete a process
                try
                {
                    p.StartInfo.UseShellExecute = false;
                
                    p.StartInfo.FileName = "ping.exe";
                    p.StartInfo.Arguments = "www.google.com -t";
                   // p.StartInfo.CreateNoWindow = true;
                    p.Start();
                   
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
