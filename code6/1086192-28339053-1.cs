    private ResourceResponse readWebResponse(HttpWebRequest webreq)
        {
            HttpWebRequest.DefaultMaximumErrorResponseLength = 1048576;
            HttpWebResponse webresp = null;// = webreq.GetResponse() as HttpWebResponse;
            var memStream = new MemoryStream();
            Stream webStream;
                try
                {
                    webresp = (HttpWebResponse)webreq.GetResponse();
                    webStream = webresp.GetResponseStream();
                    byte[] readBuffer = new byte[4096];
                    int bytesRead;
                    while ((bytesRead = webStream.Read(readBuffer, 0, readBuffer.Length)) > 0)
                        memStream.Write(readBuffer, 0, bytesRead);
                }
                catch (WebException e)
                {
                    var r = e.Response as HttpWebResponse;
                    webStream = r.GetResponseStream();
                    memStream = Read(webStream);
                    var wrongLength = memStream.Length;
                }
    
    
                memStream.Position = 0;
                StreamReader sr = new StreamReader(memStream);
                string webStreamContent = sr.ReadToEnd();
    
                byte[] responseBuffer = Encoding.UTF8.GetBytes(webStreamContent);
    //......
    //.......
