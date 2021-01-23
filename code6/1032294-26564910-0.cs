    if (Request.Content.IsMimeMultipartContent())
                {
                    var rootPath = TMP_SAVE_PATH; //some path
                    var provider = new MultipartFormDataStreamProvider(rootPath);
    
                    await Request.Content.ReadAsMultipartAsync(provider);
    
                    foreach (var fileData in provider.FileData)
                    {
                        var fileName = fileData.Headers.ContentDisposition.FileName.TrimEnd(new char[] { '\\' }).Trim(new char[] { '"' });
                        File.Move(fileData.LocalFileName, fileName); //move to some location
                    }
                }
