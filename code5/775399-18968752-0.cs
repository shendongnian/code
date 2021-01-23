    if (!Directory.Exists(destDirName))
                {                
                    Directory.CreateDirectory(destDirName);
                }
                else
                {
                    DirectoryInfo dircheck = new DirectoryInfo(destDirName);
                    DirectoryInfo[] dirscheck = dircheck.GetDirectories();
                    //Start at Device 1
                    int count = 1;
                    Item presents each file in the Destination directory
                    foreach (var item in dirscheck)
                    {
                        //If the FileName (Lets say Device 1) contained the count which is 1 then increment... Do so until you reach the last index of a device.
                        if (item.Name.Contains(count.ToString()))
                        {
                            count++;
                        }
                    }
                    
                    //Give the Destination directory the name of the last index of the count + 1
                    destDirName = holdoriginal + "Device " + count + "\\";
                    Directory.CreateDirectory(destDirName);
                   
                }
