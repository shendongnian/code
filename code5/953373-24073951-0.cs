    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://example.com/myfile.wmv");
    request.Method = WebRequestMethods.Http.Get;
    request.ContentType = "video/x-ms-wmv"; 
    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
    Stream reader = response.GetResponseStream();
    
    byte[] inBuf = new byte[response.ContentLength];
    int bytesToRead = (int)inBuf.Length;
    int bytesRead = 0;
    while (bytesToRead > 0)
    {
        int n = reader.Read(inBuf, bytesRead, bytesToRead);
        if (n == 0)
        break;
        bytesRead += n;
        bytesToRead -= n;
    }
    FileStream fstr = new FileStream(@"c:\myfile.wmv", FileMode.OpenOrCreate,
                                                         FileAccess.Write);
    fstr.Write(inBuf, 0, bytesRead);
    reader.Close();
    fstr.Close();
