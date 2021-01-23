    [HttpGet]
            public HttpResponseMessage Download(string filename)
            {
                filename = filename.Replace("\\\\", "\\").Replace("'", "").Replace("\"", "");
                if (!char.IsLetter(filename[0]))
                {
                    filename = filename.Substring(2);
                }
    
                var fileinfo = new FileInfo(filename);
                if (!fileinfo.Exists)
                {
                    throw new FileNotFoundException(fileinfo.Name);
                }
    
                try
                {
                    var excelData = File.ReadAllBytes(filename);
                    var result = new HttpResponseMessage(HttpStatusCode.OK);
                    var stream = new MemoryStream(excelData);
                    result.Content = new StreamContent(stream);
                    result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                    result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                    {
                        FileName = fileinfo.Name
                    };
                    return result;
                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.ExpectationFailed, ex);
                }
            }
