            private static void BackUpEMMC(string targetDriveLetter)
        {
            try
            {
                LogManager.All.Info("Preparing to Backup the eMMC content on external storage drive: " + targetDriveLetter.ToUpper());
                using (Process backupProcess = new Process())
                {
                    ProcessStartInfo backupInfo = new ProcessStartInfo();
                    backupInfo.FileName = @"C:\\windows\\system32\\wbadmin.exe";
                    backupInfo.Arguments = string.Format("START BACKUP -backupTarget:{0}: -include:c: -vssFull -quiet", targetDriveLetter.Trim()[0]);
                    backupInfo.UseShellExecute = false;
                    backupProcess.StartInfo = backupInfo;
                    backupProcess.Start();
                    while (!backupProcess.HasExited)
                    {
                        System.Threading.Thread.Sleep(20000);
                        LogManager.All.Info("Started eMMC content backup on external storage drive: " + targetDriveLetter.ToUpper());
                        backupProcess.WaitForExit();
                    }
                    LogManager.All.Info("Backup eMMC content on external storage drive: " + targetDriveLetter.ToUpper() + " completed successfully");
                }
            }
            catch (Exception ex)
            {
                LogManager.All.Error("Test failed during Backup eMMC content process");
                LogManager.All.Error(ex.Message);
            }
        }
