    public static Boolean PrintPDFs(string pdfFileName)
            {
                try
                {
                    Process proc = new Process();
                    proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    proc.StartInfo.Verb = "print";
    
                    //Define location of adobe reader/command line
                    //switches to launch adobe in "print" mode
                    proc.StartInfo.FileName = 
                      @"C:\Program Files (x86)\Adobe\Reader 11.0\Reader\AcroRd32.exe";
                    proc.StartInfo.Arguments = String.Format(@"/p /h {0}", pdfFileName);
                    proc.StartInfo.UseShellExecute = false;
                    proc.StartInfo.CreateNoWindow = true;
    
                    proc.Start();
                    proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    if (proc.HasExited == false)
                    {
                        proc.WaitForExit(10000);
                    }
    
                    proc.EnableRaisingEvents = true;
    
                    proc.Close();
                    KillAdobe("AcroRd32");
                    return true;
                }
                catch
                {
                    return false;
                }
            }
