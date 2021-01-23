    public async Task<HttpResponseMessage> Post()
	{
        HttpResponseMessage result = null;
        if (Request.Content.IsMimeMultipartContent())
			{
				try
				{
                    var provider = new MultipartFormDataStreamProvider(fileManager.TemporaryFilePath);
					await Request.Content.ReadAsMultipartAsync(provider);
                          foreach (MultipartFileData file in provider.FileData)
			              {
			                   logger.Info(string.Format("Uploaded file: {0}\n on path {1}", file.Headers.ContentDisposition.FileName, file.LocalFileName));
				               //do sth with the file
				          }
                    //Do sth else
                }
            }
    }
