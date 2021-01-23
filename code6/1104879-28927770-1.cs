    public static string UploadVideo(HttpPostedFileBase file, dynamic ticket)
        {
            try
            {
                var apiUrl = ticket.upload_link_secure;
                using (var client = new WebClient())
                {
                    client.Headers.Add(HttpRequestHeader.Authorization, "bearer " + AccessToken);
                    client.Headers.Add("Accept", "application/vnd.vimeo.*+json;version=3.0");
                    using (var binaryReader = new BinaryReader(file.InputStream))
                    {
                       client.UploadData(apiUrl, "PUT", binaryReader.ReadBytes(file.ContentLength));
                        //SAVE FILE TO DISK
                        //http://stackoverflow.com/questions/3914445/how-to-write-contents-of-one-file-to-another-file
                        using (FileStream writeStream = File.OpenWrite("D:\\file2.txt"))
                        {
                        BinaryWriter writer = new BinaryWriter(writeStream);
                        // create a buffer to hold the bytes 
                        byte[] buffer = new Byte[1024];
                        int bytesRead;
                        // while the read method returns bytes
                        // keep writing them to the output stream
                        while ((bytesRead =
                                binaryReader.Read(buffer, 0, 1024)) > 0)
                        {
                            writeStream.Write(buffer, 0, bytesRead);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                EventLog.LogEvent("Error uploading video: ", ex.Message, ex.ToString(),
                    EventTypes.Error, false, "");
            }
            return "Failed";
        }
