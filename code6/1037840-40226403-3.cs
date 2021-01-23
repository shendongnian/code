        // you could pass the host, port, usr, pass, and uploadFile as parameters
        public void FileUploadSFTP()
        {
            var host = "whateverthehostis.com";
            var port = 22;
            var username = "username";
            var password = "passw0rd";
            // path for file you want to upload
            var uploadFile = @"c:yourfilegoeshere.txt"; 
            using (var client = new SftpClient(host, port, username, password))
            {
                client.Connect();
                if (client.IsConnected)
                {
                    Debug.WriteLine("I'm connected to the client");
                    using (var fileStream = new FileStream(uploadFile, FileMode.Open))
                    {
                        
                        client.BufferSize = 4 * 1024; // bypass Payload error large files
                        client.UploadFile(fileStream, Path.GetFileName(uploadFile));
                    }
                }
                else
                {
                    Debug.WriteLine("I couldn't connect");
                }
            }
        }
