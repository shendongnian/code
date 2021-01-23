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
                    gsProcess.WaitForExit();
                }
                catch (Exception)
                {
                }
