    class Program
    {
        static void Main(string[] args)
        {
            const string drive = "C:";
            Console.WriteLine("Drive {0}'s Model Number is {1}", drive, GetModelFromDrive(drive));
        }
        public static string GetModelFromDrive(string driveLetter)
        {
            // Must be 2 characters long.
            // Function expects "C:" or D:"
            if (driveLetter.Length != 2)
                return "";
            try
            {
                using (var partitions = new ManagementObjectSearcher("ASSOCIATORS OF {Win32_LogicalDisk.DeviceID='" + driveLetter +
                                                 "'} WHERE ResultClass=Win32_DiskPartition"))
                {
                    foreach (var partition in partitions.Get())
                    {
                        using ( var drives = new ManagementObjectSearcher("ASSOCIATORS OF {Win32_DiskPartition.DeviceID='" +
                                                             partition["DeviceID"] +
                                                             "'} WHERE ResultClass=Win32_DiskDrive"))
                        {
                            foreach (var drive in drives.Get())
                            {
                                return (string) drive["Model"];
                            }
                        }
                    }
                }
            }
            catch
            {
                return "<unknown>";
            }
            // Not Found
            return "<unknown>";
        }
    }
