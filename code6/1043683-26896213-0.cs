    var response = (HttpWebResponse)request.GetResponse();
    byte[] data; // will eventually hold the result
    // create a MemoryStream to build the result
    using (var mstrm = new MemoryStream())
    {
        using (var s = response.GetResponseStream())
        {
            var tempBuffer = new byte[4096];
            int bytesRead;
            while ((bytesRead = s.Read(tempBuffer, 0, tempBuffer.Length)) != 0)
            {
                mstrm.Write(tempBuffer, 0, bytesRead);
            }
        }
        mstrm.Flush();
        data = mstrm.GetBuffer();
    }
    // at this point, the data[] array holds the data read from the stream.
    // data.Length will tell you how large it is.
