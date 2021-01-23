        // you could pass the host, port, usr, and pass as parameters
        public void FileUploadSFTP()
        {
            var host = "whateverthehostis.com";
            var port = 22;
            var username = "username";
            var password = "passw0rd";
            
            // http://stackoverflow.com/questions/18757097/writing-data-into-csv-file/39535867#39535867
            byte[] csvFile = DownloadCSV(); // Function returns byte[] csv file
            using (var client = new SftpClient(host, port, username, password))
            {
                client.Connect();
                if (client.IsConnected)
                {
                    Debug.WriteLine("I'm connected to the client");
                    using (var ms = new MemoryStream(csvFile))
                    {
                        client.BufferSize = (uint)ms.Length; // bypass Payload error large files
                        client.UploadFile(ms, GetListFileName());
                    }
                }
                else
                {
                    Debug.WriteLine("I couldn't connect");
                }
            }
        }
