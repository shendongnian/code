                StringBuilder localSB = new StringBuilder();
                StringBuilder netSB = new StringBuilder();
                DriveInfo[] drives = DriveInfo.GetDrives();
                foreach (DriveInfo drive in drives)
                {
                    string loc = string.Empty;
                    string net = string.Empty;
                    bool isLocal = IsLocalDrive(drive.Name);
                    if (isLocal)
                    {
                        loc = drive.Name;
                    }
                    else
                    {
                        net = drive.Name;
                    }
                    if (!String.IsNullOrEmpty(loc))
                    {
                        localSB.Append(string.Format("{0} ~ ", loc));
                    }
                    if (!String.IsNullOrEmpty(net))
                    {
                        netSB.Append(string.Format("{0} ~ ", net));
                    }
                }
                string localFinal = localSB.ToString();
                string netFinal = netSB.ToString();
