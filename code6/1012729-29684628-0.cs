     public async bool SendRequestAsync(string requestUrl, object data) 
        {
            string json = JsonConvert.SerializeObject(obj, Formatting.Indented,
                                     new JsonSerializerSettings
                                     {
                                         ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                                     });
    
            try
            {
                HttpWebRequest request = WebRequest.Create(requestUrl) as HttpWebRequest;
    
                if (request != null)
                {
                    request.Accept = "application/json";
                    request.ContentType = "application/json";
                    request.Method = "POST";
    
                    using (var stream = new StreamWriter(await request.GetRequestStreamAsync()))
                    {
                        stream.Write(json);
                    }
    
                    using (HttpWebResponse response = await request.GetResponseAsync() as HttpWebResponse)
                    {
                        if (response != null && response.StatusCode != HttpStatusCode.OK)
                            throw new Exception(String.Format(
                                "Server error (HTTP {0}: {1}).",
                                response.StatusCode,
                                response.StatusDescription));
    
                        if (response != null)
                        {
                            Stream responseStream = response.GetResponseStream();
                            //return true or false depending on the ok
                            return GetResponseModel(responseStream);
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                var response = ex.Response;
                Stream respStream = response.GetResponseStream();
                //return true or false depending on the ok
                return GetResponseModel(respStream);
    
            }
            catch (Exception e)
            {
                return false;
            }
    
            return false;
        }
