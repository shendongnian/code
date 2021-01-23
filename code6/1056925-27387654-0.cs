    private void FtpNlistRecursive(string pPath)
        {
            try
            {
                DirectoryListOfCurrent = new List<string>();
                _ftpServerFullPath = "ftp://" + _serverIP + ":" + _serverPort + "/" + pPath;
                string newItem = "";
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(_ftpServerFullPath);
                request.Method = WebRequestMethods.Ftp.ListDirectory;
                request.Credentials = new NetworkCredential(_username, _password);
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream);
                while (!reader.EndOfStream)
                {
                    newItem = reader.ReadLine();
                    string shortItem = pPath.Substring(pPath.IndexOf(@"/") + 1); // Aus "Ornder1/Datei1.txt" wird "Datei1.txt"
                    if (!shortItem.Equals(newItem))
                    {
                        try
                        {
                            if (pPath.Equals("/"))
                            {
                                DirectoryListOfCurrent.Add(newItem);
                                directoryListOfAll.Add(newItem);
                            }
                            else
                            {
                                string completePath = pPath + newItem.Substring(newItem.IndexOf(@"/"));
                                DirectoryListOfCurrent.Add(completePath);
                                directoryListOfAll.Add(completePath);
                            }
                        }
                        catch (ArgumentOutOfRangeException ex)
                        {
                            //bei ZB "Datei3.txt" gibt es kein "/", somit einfach ignorieren
                        }
                    }
                }
                reader.Close();
                response.Close();
                foreach (string item in DirectoryListOfCurrent)
                {
                    FtpNlistRecursive(item);
                }
            }
            catch (Exception ex)
            {
                ExceptionOccurs(ex);
            }
        }
