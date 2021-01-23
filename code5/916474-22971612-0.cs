        public T DeserializeContractData<T>(HttpContext context) where T: new()
        {
            try
            {
                using (var inputStream = new StreamReader(context.Request.InputStream))
                {
                    var json = inputStream.ReadToEnd();
                    return JsonConvert.DeserializeObject<T>(json);
                }
            }
            catch (JsonSerializationException e)
            {
                //maybe do some logging...
                return default(T);
            }
        }
