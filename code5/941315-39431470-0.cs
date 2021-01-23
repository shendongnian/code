           public void DownloadAll()
        {
            string host = @"sftp.domain.com";
            string username = "myusername";
            string password = "mypassword";
            
            string remoteDirectory = "/RemotePath/";
            string localDirectory = @"C:\LocalDriveFolder\Downloaded\";
            using (var sftp = new SftpClient(host, username, password))
            {
                sftp.Connect();
                var files = sftp.ListDirectory(remoteDirectory);
                
                foreach (var file in files)
                {
                    string remoteFileName = file.Name;
                    if ((!file.Name.StartsWith(".")) && ((file.LastWriteTime.Date == DateTime.Today))
                        using (Stream file1 = File.OpenWrite(localDirectory + remoteFileName))
                        { 
                            sftp.DownloadFile(remoteDirectory + remoteFileName, file1);
                        }
                }
            }
        }
