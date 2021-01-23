     class WebReader
        {
            private string onlineText = "";
            public string getOnlineText()
            {
                return onlineText;
            }
            public WebReader(String strLocation,String strFile){
                Stream strm = null;
                StreamReader MyReader = null;
    
                try
                {
                    // Download the web page.
                    strm = GetURLStream("http://" + strLocation +"/" + strFile);
                    if (strm != null)
                    {
                        // We have a stream, let's attach a byte reader.
                        char[] strBuffer = new char[3001];
    
                        MyReader = new StreamReader(strm);
    
                        // Read 3,000 bytes at a time until we get the whole file.
                        string strLine = "";
                        while (MyReader.Read(strBuffer, 0, 3000) > 0)
                        {
                            strLine += new string(strBuffer);
                            
                        }
                        onlineText = strLine;
                    }
                }
                catch (Exception excep)
                {
                    Console.WriteLine("Error: " + excep.Message);
                }
                finally
                {
                    // Clean up and close the stream.
                    if (MyReader != null)
                    {
                        MyReader.Close();
                    }
    
                    if (strm != null)
                    {
                    strm.Close();
                    }
                }
            }
            public Stream GetURLStream(string strURL)
            {
                System.Net.WebRequest objRequest;
                System.Net.WebResponse objResponse = null;
                Stream objStreamReceive;
    
                try
                {
                    objRequest = System.Net.WebRequest.Create(strURL);
                    objRequest.Timeout = 5000;
                   
    
                    objResponse = objRequest.GetResponse();
                    objStreamReceive = objResponse.GetResponseStream();
    
                    return objStreamReceive;
                }
                catch (Exception excep)
                {
                    Console.WriteLine(excep.Message);
                    objResponse.Close();
    
                    return null;
                }
            }
    
            public void ReadWriteStream(Stream readStream, Stream writeStream, frmUpdater _MyParent, int CurrentVersion, long BytesCompleted)
            {
                int Length = 2048;
                Byte[] buffer = new Byte[Length];
                int bytesRead = readStream.Read(buffer, 0, Length);
                // write the required bytes
                while (bytesRead > 0)
                {
                    writeStream.Write(buffer, 0, bytesRead);
                    bytesRead = readStream.Read(buffer, 0, Length);
                    _MyParent.RefreshDownloadLabels(CurrentVersion,BytesCompleted + writeStream.Position);
                    Application.DoEvents();
                }
                readStream.Close();
                writeStream.Close();
            }
        }
