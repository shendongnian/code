            public HttpStatusCode Post(string fileName)
            {
                        var task = this.Request.Content.ReadAsStreamAsync();
                        task.Wait();
                        Stream requestStream = task.Result;
            
                        try
                        {
                            Stream fileStream =    File.Create(HttpContext.Current.Server.MapPath("~/" + fileName));
                            requestStream.CopyTo(fileStream);
                            fileStream.Close();
                            requestStream.Close();
                        }
                        catch (IOException)
                        {
                            throw new HttpResponseException(HttpStatusCode.InternalServerError);
                        }
            
                        HttpResponseMessage response = new HttpResponseMessage();
                        response.StatusCode = HttpStatusCode.Created;
                        return response.StatusCode;
            
            }
