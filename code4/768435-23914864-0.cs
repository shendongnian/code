    foreach (var file in ftpClient.GetListing(newpath, FtpListOption.Modify))
                    {
                        //Console.WriteLine(file.Modified);
                        if (file.Modified > lastRunTime)
                            {
                            //Download the file if it is newer than the last recorded run time.
                            //WriteLine is for debugging purposes
                            Console.WriteLine(file.Name);
                            }
                    }
