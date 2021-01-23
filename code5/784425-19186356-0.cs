     try
            {
                DriveInfo[] myDrives = DriveInfo.GetDrives();
                foreach (DriveInfo drive in myDrives)
                {
                    Console.WriteLine("Drive:" + drive.Name);
                    Console.WriteLine("Drive Type:" + drive.DriveType);
 
                    if (drive.IsReady == true)
                    {
                        Console.WriteLine("Vol Label:" + drive.VolumeLabel);
                        Console.WriteLine("File System: " + drive.DriveFormat);
                    }
                }
            }
            catch (Exception)
            {
                
                throw;
            }
