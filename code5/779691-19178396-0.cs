          try
            {
                var psi = new ProcessStartInfo(@"C:\Program Files (x86)\Windows Kits\8.1\Tools\x64\devcon.exe");
                {
                    psi.UseShellExecute = false;
                };
                psi.Arguments = @"disable *mou";
                Process pDisable = Process.Start(psi);
                psi.Arguments = @"enable *mou";
                Process pEnable = Process.Start(psi);
                Console.ReadLine();
            }
            catch(Exception e)
            {
                string message = e.Message;
            }
