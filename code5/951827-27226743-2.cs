    private object GetRestResponseAsObject(HttpWebRequest request)
        {
            using (var response = (HttpWebResponse)request.GetResponse())
            {
                using (Stream input = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(input);
                    string buffer = reader.ReadToEnd();
                    var responseObj = serializer.DeserializeObject(buffer);
                    return responseObj;
                }
            }
        }
