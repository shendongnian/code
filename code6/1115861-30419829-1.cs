     public static string DoJsonRequest(string url, MemoryStream content)
            {
    
                byte[] dataByte = content.ToArray();
    
                //create http web request obj
                WebRequest postRequest = WebRequest.Create(url);
                //Method type
                postRequest.Method = "POST";
                // Data type - message body coming in xml
                postRequest.ContentType = "application/json; charset=utf-8";
                //Content length of message body
                postRequest.ContentLength = dataByte.Length;
    
                // Get the request stream
                using (Stream postStream = postRequest.GetRequestStream())
                {
                    // Write the data bytes in the request stream
                    postStream.Write(dataByte, 0, dataByte.Length);
                    //Get response from server
                    using (HttpWebResponse postResponse = (HttpWebResponse)postRequest.GetResponse())
                    {
                        using (StreamReader reader = new StreamReader(postResponse.GetResponseStream()))
                        {
                            return reader.ReadToEnd();
                        }
                    }
                }
            }
    
            public static string GetJsonFromObject<TObject>(TObject obj, IEnumerable<Type> types)
            {
                using (var stream = new MemoryStream())
                {
                    var jsSerializer = new DataContractJsonSerializer(typeof(TObject), types);
    
                    jsSerializer.WriteObject(stream, obj);
                    stream.Position = 0;
    
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        string json = reader.ReadToEnd();
                        return json;
                    }
                }
            }
    
    public static TObject GetObjectFromJson<TObject>(string json, IEnumerable<Type> types)
    {
        using (MemoryStream stream = new MemoryStream())
        {
            using (StreamWriter writer = new StreamWriter(stream))
            {
                writer.Write(json);
                writer.Flush();
                stream.Position = 0;
                var jsSerializer = new DataContractJsonSerializer(typeof(TObject), types);
                TObject obj = (TObject)jsSerializer.ReadObject(stream);
                return obj;
            }
        }
    }
