    public Dictionary<string, string> GetDrives()
            {
                var result = new Dictionary<string, string>();
                foreach ( var drive in new ManagementObjectSearcher( "Select * from Win32_LogicalDiskToPartition" ).Get().Cast<ManagementObject>().ToList() )
                {
                    var driveLetter = Regex.Match( (string)drive[ "Dependent" ], @"DeviceID=""(.*)""" ).Groups[ 1 ].Value;
                    var driveNumber = Regex.Match( (string)drive[ "Antecedent" ], @"Disk #(\d*)," ).Groups[ 1 ].Value;
                    result.Add( driveLetter, driveNumber );
                }
                return result;
            }
