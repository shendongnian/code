    public static TResponse DoJsonRequest<TRequest, TResponse>(string url,   TRequest content)
            where TResponse : new()
            where TRequest : new()
        {
            byte[] dataByte = GetJsonMemoryStreamFromObject<TRequest>(content).ToArray();
            //create http web request obj
            HttpWebRequest postRequest = (HttpWebRequest)WebRequest.Create(url);
            //Method type
            postRequest.Method = "POST";
            // Data type - message body coming in xml
            postRequest.ContentType = "application/json";
            postRequest.KeepAlive = true;
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
                    return GetObjectFromStream<TResponse>(postResponse.GetResponseStream());
                }
            }
        }
        public static MemoryStream GetJsonMemoryStreamFromObject<TObject>(TObject obj)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            string objSerialized = js.Serialize(obj);
            var jsSerializer = new DataContractJsonSerializer(typeof(string));
            using (var stream = new MemoryStream())
            {
                jsSerializer.WriteObject(stream, objSerialized);
                stream.Position = 0;
                return stream;
            }
        }
        public static TObject GetObjectFromStream<TObject>(Stream stream)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            var jsSerializer = new DataContractJsonSerializer(typeof(string));
            object obj = jsSerializer.ReadObject(stream);
            return (TObject)js.Deserialize(obj.ToString(), typeof(TObject));
        }
    }
