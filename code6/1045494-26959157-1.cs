            uint volumeSerialNumber = 0;
            bool DriveFound = false;
            foreach (ManagementObject drive in new ManagementObjectSearcher("select DeviceID, Signature from Win32_DiskDrive").Get())
            {
                foreach (ManagementObject partition in new ManagementObjectSearcher(String.Format("associators of {{Win32_DiskDrive.DeviceID='{0}'}} where AssocClass = Win32_DiskDriveToDiskPartition", drive["DeviceID"])).Get())
                {
                    if (partition != null)
                    {
                        ManagementObject logical = new ManagementObjectSearcher(String.Format("associators of {{Win32_DiskPartition.DeviceID='{0}'}} where AssocClass = Win32_LogicalDiskToPartition", partition["DeviceID"])).First();
                        if (logical != null)
                        {
                            if (logical["Name"] != null)
                            {
                                string logicalName = logical["Name"].ToString();
                                if (logicalName[0] == Drive)
                                {
                                    volumeSerialNumber = (uint)drive["Signature"];
                                    DriveFound = true;
                                    break;
                                }
                            }
                        }
                    }
                }
                if (DriveFound)
                    break;
            }
             var serial = volumeSerialNumber.ToString("x");
                while (serial.Length < 8)
                {
                    serial = serial.Insert(0, "0");
                }
                return serial.ToUpper();
       }
