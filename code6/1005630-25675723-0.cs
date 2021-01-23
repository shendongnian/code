    public async void SendInventoryXML(String userId, String pwd, String fileName)
    {
        var stream = await Request.Content.ReadAsStreamAsync()
        MemoryStream ms = new MemoryStream();
        await stream.CopyToAsync(ms);
        //ms.Flush(); Not needed, Flush does nothing in MemoryStream. See: http://referencesource.microsoft.com/#mscorlib/system/io/memorystream.cs
        ms.Position = 0;
    
        XDocument doc = XDocument.Load(ms);
        String saveLoc = String.Format(@"C:\HDP\{0}.xml", fileName);
        doc.Save(saveLoc);
    }
