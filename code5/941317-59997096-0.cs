    var files = sftp.ListDirectory(remoteVendorDirectory).Where(f => f.IsDirectory == false);
                    foreach (var file in files)
                    {
                        var filename = $"{LocalDirectory}/{file.Name}";
                        if (!File.Exists(filename))
                        {
                            Console.WriteLine("Downloading  " + file.FullName);
                            var localFile = File.OpenWrite(filename);
                            sftp.DownloadFile(file.FullName, localFile);
                        }
                    }
