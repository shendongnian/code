            static void DownloadAll()
        {
            string host = "xxx.xxx.xxx.xxx";
            string username = "@@@";
            string password = "123";string remoteDirectory = "/IN/";
            string finalDir = "";
            string localDirectory = @"C:\filesDN\";
            string localDirectoryZip = @"C:\filesDN\ZIP\";
            using (var sftp = new SftpClient(host, username, password))
            {
                Console.WriteLine("Connecting to " + host + " as " + username);
                sftp.Connect();
                Console.WriteLine("Connected!");
                var files = sftp.ListDirectory(remoteDirectory);
                foreach (var file in files)
                {
                    string remoteFileName = file.Name;
                    
                    if ((!file.Name.StartsWith(".")) && ((file.LastWriteTime.Date == DateTime.Today)))
                    { 
                    
                        if (!file.Name.Contains(".TXT"))
                        {
                            finalDir = localDirectoryZip;
                        } 
                        else 
                        {
                            finalDir = localDirectory;
                        }
                    
                   
                        if (File.Exists(finalDir  + file.Name))
                        {
                            Console.WriteLine("File " + file.Name + " Exists");
                        }else{
                            Console.WriteLine("Downloading file: " + file.Name);
                              using (Stream file1 = File.OpenWrite(finalDir + remoteFileName))
                        {
                            sftp.DownloadFile(remoteDirectory + remoteFileName, file1);
                        }
                        }
                    }
                }
               
                
                
                Console.ReadLine();
            }
