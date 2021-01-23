    byte[] byteArray = Encoding.ASCII.GetBytes(sw.ToString());
    MemoryStream s = new MemoryStream(byteArray);
    StreamReader sr = new StreamReader(s, Encoding.ASCII);
    
    Response.Write(sr.ReadToEnd());
    Response.End();
