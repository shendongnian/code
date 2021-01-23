    // Setup session options
                        SessionOptions sessionOptions = new SessionOptions
                        {
                            Protocol = Protocol.Sftp,
                            HostName = "000.00.00.000",
                            UserName = "xxxxxx",
                            Password = "xxxxxx",
                            PortNumber= 22,
                            SshHostKeyFingerprint = "ssh-rsa 2048 xxxxxxxxxxxxxxx"
                        };
        
                        using (Session session = new Session())
                        {
                            // Connect
                            session.Open(sessionOptions);
        
                            // Upload files
                            //TransferOptions transferOptions = new TransferOptions();
                            //transferOptions.TransferMode = TransferMode.Binary;
        
                            //TransferOperationResult transferResult;
                            var results = session.ListDirectory("/path");
                            foreach (RemoteFileInfo item in results.Files)
                            {
                                Console.WriteLine(item.Name);
                            }
        
                            // Throw on any error
                            //transferResult.Check();
        
                            // Print results
                            //foreach (TransferEventArgs transfer in transferResult.Transfers)
                            //{
                            //    Console.WriteLine("Upload of {0} succeeded", transfer.FileName);
                            //}
                        }
        
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Error: {0}", e);
                    }
