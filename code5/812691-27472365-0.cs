    private static string sendHttpRequest(string url, NameValueCollection values, NameValueCollection files = null)
    {
        string boundary = "----------------------------" + DateTime.Now.Ticks.ToString("x");
        // The first boundary
        byte[] boundaryBytes = System.Text.Encoding.UTF8.GetBytes("\r\n--" + boundary + "\r\n");
        // The last boundary
        byte[] trailer = System.Text.Encoding.UTF8.GetBytes("\r\n--" + boundary + "--\r\n");
        // The first time it itereates, we need to make sure it doesn't put too many new paragraphs down or it completely messes up poor webbrick
        byte[] boundaryBytesF = System.Text.Encoding.ASCII.GetBytes("--" + boundary + "\r\n");
    
        // Create the request and set parameters
        HttpWebRequest request = (HttpWebRequest) WebRequest.Create(url);
        request.ContentType = "multipart/form-data; boundary=" + boundary;
        request.Method = "POST";
        request.KeepAlive = true;
        request.Credentials = System.Net.CredentialCache.DefaultCredentials;
    
        // Get request stream
        Stream requestStream = request.GetRequestStream();
    
        foreach (string key in values.Keys)
        {
            // Write item to stream
            byte[] formItemBytes = System.Text.Encoding.UTF8.GetBytes(string.Format("Content-Disposition: form-data; name=\"{0}\";\r\n\r\n{1}", key, values[key]));
            requestStream.Write(boundaryBytes, 0, boundaryBytes.Length);
            requestStream.Write(formItemBytes, 0, formItemBytes.Length);
        }
    
        if (files != null)
        { 
            foreach(string key in files.Keys)
            {
                if(File.Exists(files[key]))
                {
                    int bytesRead = 0;
                    byte[] buffer = new byte[2048];
                    byte[] formItemBytes = System.Text.Encoding.UTF8.GetBytes(string.Format("Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: application/octet-stream\r\n\r\n", key, files[key]));
                    requestStream.Write(boundaryBytes, 0, boundaryBytes.Length);
                    requestStream.Write(formItemBytes, 0, formItemBytes.Length);
    
                    using (FileStream fileStream = new FileStream(files[key], FileMode.Open, FileAccess.Read))
                    {
                        while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
                        {
                            // Write file content to stream, byte by byte
                            requestStream.Write(buffer, 0, bytesRead);
                        }
    
                        fileStream.Close();
                    }
                }
            }
        }
    
        // Write trailer and close stream
        requestStream.Write(trailer, 0, trailer.Length);
        requestStream.Close();
    
        using (StreamReader reader = new StreamReader(request.GetResponse().GetResponseStream()))
        {
            return reader.ReadToEnd();
        };
    }
