    string url = "https://test/code/304fd9c6-7e53-42a2-845a-624608bfd2ce.zip";
    WebRequest webRequest = WebRequest.Create(url);
    webRequest.Method = "GET";
    WebResponse webResponse = webRequest.GetResponse();
    using (var responseStream = webResponse.GetResponseStream())
    using (var ms = new MemoryStream())
    {
        // Copy entire file into memory. Use a file if you expect a lot of data
        responseStream.CopyTo(ms);
        var zipFile = new ZipFile(ms);
        foreach (ZipEntry item in zipFile)
        {
            Console.WriteLine(item.Name);
            using (var s = new StreamReader(zipFile.GetInputStream(item)))
            {
                Console.WriteLine(s.ReadToEnd());
            }
        }
    }
    Console.Read();
