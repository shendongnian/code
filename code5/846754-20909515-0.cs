    [HttpPost]
    [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
    [Route("UploadFile")]
    public async Task UploadFile(string fileName, string description)
    {
       byte[] fileContents = await Request.Content.ReadAsByteArrayAsync();
   
       ....
    }
