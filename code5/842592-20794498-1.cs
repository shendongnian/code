    if you use linux server  [visit this link as well][1] 
    
    
         private static void UploadFile(string dir, Uri target, string fileName, string username, string password, string finilizingDir, string startupPath, string logFileDirectoryName)
                {
                    try
                    {
                        // Get the object used to communicate with the server.
                        FtpWebRequest request = (FtpWebRequest)WebRequest.Create(target);
                        request.Proxy = null;
                        request.Method = WebRequestMethods.Ftp.UploadFile;
        
                        // logon.
                        request.Credentials = new NetworkCredential(username, password);
        
                        // Copy the contents of the file to the request stream.
                        StreamReader sourceStream = new StreamReader(dir + "\\" + fileName);
                        byte[] fileContents = Encoding.UTF8.GetBytes(sourceStream.ReadToEnd());
                        sourceStream.Close();
                        request.ContentLength = fileContents.Length;
        
                        Stream requestStream = request.GetRequestStream();
        
                        requestStream.Write(fileContents, 0, fileContents.Length);
                        requestStream.Close();
        
                        FtpWebResponse response = (FtpWebResponse)request.GetResponse();
        
                        if (response.StatusCode == FtpStatusCode.ClosingData)
                        {
                           Console.WriteLine(" --> Status Code is :" + response.StatusCode);
                        }
                        
                         Console.WriteLine(" --> Upload File Complete With Status Description :" + response.StatusDescription);
        
                        response.Close();
                    }
                    catch (Exception ex)
                    {
                         Console.WriteLine("*** Error Occurred while uploading file :" + fileName + " System Says :" + ex.Message + " **********END OF ERROR**********");
                    }
                }
