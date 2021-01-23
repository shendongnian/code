     DriveInfo[] ListDrives = DriveInfo.GetDrives();
    
                foreach (DriveInfo Drive in ListDrives)
                {
                    if (Drive.DriveType == DriveType.Removable)
                    {
                        try
                        {
                            Console.WriteLine(Drive.Name);
                        }
                        catch (Exception ex)
                        {    
                            Console.WriteLine(ex.Message);
                        }                     
                    }
                }
