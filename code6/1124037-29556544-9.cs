    try
            {
                //string txtDescription = "Test";
                string txtFileName = "Invoice_50000.xml";
                //byte[] fileToSend = File.ReadAllBytes(txtFileName)
                // Create the REST request.
                string url = "http://localhost:8000/Service1/";//ConfigurationManager.AppSettings["serviceUrl"];
                //string requestUrl = string.Format("{0}/Upload/{1}/{2}", url, System.IO.Path.GetFileName(txtFileName), txtDescription);
                /* Asynchronous */
                string requestUrl = string.Format("{0}/asyncupload/", url);
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(requestUrl); 
                
                using (FileStream inputStream = File.Open(txtFileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    //new BufferedStream
                    //new Buffer                
                    request.SendChunked = true;
                    request.AllowWriteStreamBuffering = false;
                    request.Method = "PUT";
                    request.ContentType = "application/octet-stream";
                    //request.ContentType = MediaTypeNames.Application.Octet
                    request.ContentLength = inputStream.Length;
                    /* BEGIN: Solution with chunks */
                    // 64 KB buffer
                    byte[] chunkBuffer = new byte[0x10000];
                    Stream st = request.GetRequestStream();
                    // as the file is streamed up in chunks, the server will be processing the file
                    int bytesRead = inputStream.Read(chunkBuffer, 0, chunkBuffer.Length);
                    while (bytesRead > 0)
                    {
                        st.Write(chunkBuffer, 0, bytesRead);
                        bytesRead = inputStream.Read(chunkBuffer, 0, chunkBuffer.Length);
                    }
                    st.Close();
                }
                try
                {
                    HttpWebResponse resp = (HttpWebResponse)request.GetResponse();
                    Console.WriteLine("HTTP/{0} {1} {2}", resp.ProtocolVersion, (int)resp.StatusCode, resp.StatusDescription);
                    resp.Close();
                }
                catch (System.Exception)
                {
                    //TODO: error handling here.
                }
                /* END: Solution with chunks */
            }
