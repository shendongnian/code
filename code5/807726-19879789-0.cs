    WebRequest wreq = (HttpWebRequest)WebRequest.Create(url);
    using (HttpWebResponse wresp = (HttpWebResponse)wreq.GetResponse())
    using (Stream mystream = wresp.GetResponseStream())
    {
      using (BinaryReader reader = new BinaryReader(mystream))
      {
        int length = Convert.ToInt32(wresp.ContentLength);
        byte[] buffer = new byte[length];
        buffer = reader.ReadBytes(length);
    
        Response.Clear();
        Response.Buffer = false;
        Response.ContentType = "video/mp4";
        while(true) {
        int bytesRead = myStream.Read(buffer, 0, buffer.Length);
        if (bytesRead == 0) break;
        Response.OutputStream.Write(buffer, 0, bytesRead);
    }
        Response.End();
      }
    }
