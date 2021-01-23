    public async void SendInventoryXML(String userId, String pwd, String fileName)
    {
        Task task = Request.Content.ReadAsStreamAsync().ContinueWith(t =>
        {
            var stream = t.Result;
            using (FileStream fileStream = File.Create(String.Format(@"C:\HDP\{0}.xml", fileName), (int) stream.Length)) 
            {
                byte[] bytesInStream = new byte[stream.Length];
                stream.Read(bytesInStream, 0, (int) bytesInStream.Length);
                fileStream.Write(bytesInStream, 0, bytesInStream.Length);
            }
        });
    }
