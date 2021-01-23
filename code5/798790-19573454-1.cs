    var ms = new System.IO.MemoryStream();
    byte[] buffer = new byte[4096];
    int bytesRead = 0;
    do
    {
        bytesRead = stream.Read(buffer, 0, buffer.Length);
        ms.Write(buffer, 0, bytesRead);
    }
    while (stream.DataAvailable);
    string jsonString = System.Text.Encoding.UTF8.GetString(ms.ToArray());
