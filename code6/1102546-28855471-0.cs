            var myExe = "/bin/rkill.exe";
            // Find removable drives
            var driveDirectories = 
                DriveInfo.GetDrives()
                .Where(d => d.DriveType == DriveType.Removable)
                .Select(d => d.RootDirectory.FullName);
            foreach (var directory in driveDirectories)
            {
                // create full path
                var fullPath = Path.Combine(directory, myExe);
 
                // check if path exists
                if (File.Exists(fullPath))
                {
                    // execute
                    var process_RKill = new Process
                    {
                        StartInfo = new ProcessStartInfo
                        {
                            FileName = fullPath;
                        }
                    };
                    process_RKill.Start();
                    process_RKill.WaitForExit();
                    // don't try other drives after successful execution
                    return;
                }
            }
