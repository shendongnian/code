                foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                if (drive.IsReady && drive.Name == "E:\\")
                {
                    if (drive.TotalFreeSpace <= 245000000000000)
                    {
                        try
                        {
                            while (drive.TotalFreeSpace <= 245000000000000)
                            {
                                DirectoryInfo info = new DirectoryInfo(@"E:\REC\Video\");
                                FileInfo[] files = info.GetFiles().OrderBy(p => p.LastWriteTime).ToArray();
                                System.IO.File.Delete(@"E:\REC\Video\" + files[0].Name);
                            }
                        }
                        catch
                        {
                        }
                    }
                }
            }
