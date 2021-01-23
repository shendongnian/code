    string tempFile = @"C:\test.pdf";
                try
                {
                    ProcessStartInfo gsProcessInfo;
                    Process gsProcess;
                    string printerName = PrinterName; 
           
                    gsProcessInfo = new ProcessStartInfo();
                    gsProcessInfo.Verb = "PrintTo";
                    gsProcessInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    gsProcessInfo.FileName = tempFile;
                    gsProcessInfo.Arguments = "\"" + printerName + "\"";
                    gsProcess = Process.Start(gsProcessInfo);
                    if (gsProcess.HasExited == false)
                    {
                        gsProcess.Kill();
                    }
                    gsProcess.EnableRaisingEvents = true;
                    
                    gsProcess.Close();
                }
                catch (Exception)
                {
                }
