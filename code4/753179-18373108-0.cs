    public int GetAvailableDisks()
            {
                int  deviceFound = 0;
                try
                {
                    // browse all USB WMI physical disks
                    foreach (ManagementObject drive in
                        new ManagementObjectSearcher(
                            "select DeviceID, Model from Win32_DiskDrive where InterfaceType='USB'").Get())
                    {
                        ManagementObject partition = new ManagementObjectSearcher(String.Format(
                            "associators of {{Win32_DiskDrive.DeviceID='{0}'}} where AssocClass = Win32_DiskDriveToDiskPartition",
                            drive["DeviceID"])).First();
                        if (partition == null) continue;
                        // associate partitions with logical disks (drive letter volumes)
                        ManagementObject logical = new ManagementObjectSearcher(String.Format(
                            "associators of {{Win32_DiskPartition.DeviceID='{0}'}} where AssocClass = Win32_LogicalDiskToPartition",
                            partition["DeviceID"])).First();
                        if (logical != null)
                        {
                            // finally find the logical disk entry to determine the volume name - Not necesssary 
                            //ManagementObject volume = new ManagementObjectSearcher(String.Format(
                            //    "select FreeSpace, Size, VolumeName from Win32_LogicalDisk where Name='{0}'",
                            //    logical["Name"])).First();
    
                            string temp = logical["Name"].ToString() + "\\";
                            // +" " + volume["VolumeName"].ToString(); Future purpose if Device Name required
    
                            deviceFound++;
                            if (deviceFound > 1)
                            {
                                MessageBox.Show(@"Multiple Removeable media found. Please remove the another device");
                                deviceFound--;
    
                            }
                            else
                            {
                                driveName = temp;
                            }
    
                        }
                    }
                }
                catch (Exception diskEnumerateException)
                {
    
                }
                return deviceFound;
            }
