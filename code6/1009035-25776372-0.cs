    [HttpPost]
    [Route("api/inventory/sendxml/{userId}/{pwd}/{filename}")]
    public async void SendInventoryXML(String userId, String pwd, String fileName)
    {
        var stream = await Request.Content.ReadAsStreamAsync();
        using (FileStream fileStream = File.Create(String.Format(@"C:\HDP\{0}.xml", fileName), (int)stream.Length))
        {
            byte[] bytesInStream = new byte[stream.Length];
            stream.Read(bytesInStream, 0, (int)bytesInStream.Length);
            fileStream.Write(bytesInStream, 0, bytesInStream.Length);
        }
    }
