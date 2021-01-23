    const int MAX_BUFFER = 33554432; //32MB
    byte[] buffer = new byte[MAX_BUFFER];
    int bytesRead;
    using (FileStream fs = File.Open(filePath, FileMode.Open, FileAccess.Read))
    using (BufferedStream bs = new BufferedStream(fs))
    {
        string line;
        bool stop = false;
        var memoryStream = new MemoryStream(buffer);
        var stream = new StreamReader(memoryStream);
        while ((bytesRead = bs.Read(buffer, 0, MAX_BUFFER)) != 0)
        {
            memoryStream.Seek(0, SeekOrigin.Begin);
            
            while ((line = stream.ReadLine()) != null)
            {
                //process line
            }
        }
    }
