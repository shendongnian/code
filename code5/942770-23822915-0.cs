     string serverPath = @"D:\Anand\Work\FolderCheck\Server";    //Source File
     string clientPath = @"D:\Anand\Work\FolderCheck\Client";   //destination Folder
      private static bool CompareFileSizes(string fileServer, string fileClient)
        {
            bool fileSizeEqual = true;
            if (fileServer.Length == fileClient.Length)  // Compare file sizes
            {
                fileSizeEqual = false;        // File sizes are not equal therefore files are not identical
            }
            return fileSizeEqual;
        }
     try
            {
                if (!File.Exists(serverPath) || !File.Exists(clientPath))
                {
                    try
                    {
                        var Server = Path.GetFileName(serverPath);
                        var Client = Path.GetFileName(clientPath);
                        string ServerFile = Server.ToString();
                        string ClientFile = Client.ToString();
                        if (CompareFileSizes(ServerFile, ClientFile))
                        {
                            lblServerMsg.Text = "No Updates are Found: ";
                        }
                        else
                        {
                            var directoryServer = new DirectoryInfo(@"D:\Anand\Work\FolderCheck\Server"); //check latest Available File From Server                          
                            var myFile = (from f in directoryServer.GetFiles()
                                          orderby f.LastWriteTime descending
                                          select f).First();
                          
                            lblServerMsg.Text = "Updates Are Available Click for Update Button:";
                            btnCheckUpates.Visible = false;
                            btnUpdates.Visible = true;
                        }
                    }
                    catch (Exception msg)
                    {
                        lblServerMsg.Text = "No Updates are Found: " + msg.Message;
                    }
                }
                else
                {
                    throw new FileNotFoundException();
                }
            }
            catch (FileNotFoundException ex)
            {
                lblServerMsg.Text = ex.Message;
            }
