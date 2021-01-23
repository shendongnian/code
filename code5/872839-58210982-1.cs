    using (FtpClient client = new FtpClient())
            {
                client.Host = ftpAddress;
                client.Credentials = new NetworkCredential(ftpUserName, ftpPassword);
                client.Port = 21;
                client.Connect();
                using (Stream s = new FileStream(localPathWithFileName, FileMode.Open))
                {
                    try
                    {
                        //log.Info($"Uploading file...");
                        client.Upload(s, ftpFilePathWithFileName);
                        //log.Info($"File uploaded!");
                    }
                    catch(Exception e)
                    {
                        //log.Info($"{e.StackTrace}");
                    }
                    finally
                    {
                        client.Disconnect();
                    }
                }
       
            }
