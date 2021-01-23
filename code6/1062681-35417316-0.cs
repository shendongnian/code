    string[] folderArray = directory.Split('/');
                                        string folderName = "";
                                        for (int i = 0; i < folderArray.Length; i++)
                                        {
                                           if(!string.IsNullOrEmpty(folderArray[i]))
                                            {
                                                folderName = string.IsNullOrEmpty(folderName) ? folderArray[i] : folderName + "/" + folderArray[i];
                                                WebRequest request = WebRequest.Create("ftp://" + ftpAddress + "/" + folderName);
                                                request.Method = WebRequestMethods.Ftp.MakeDirectory;
                                                request.Credentials = new NetworkCredential(username, password);
                                                var response = request.GetResponse();
                                                var test = response.ToString();
                                            }
                                        }
