    public async Task<HttpResponseMessage> Get() {
       var stream = await Request.Content.ReadAsStreamAsync();
       
       var xmlDocument = new XmlDocument();
       xmlDocument.Load(stream);
       // Process XML document
       return new HttpResponseMessage();
    }
