            using (ExtendedWebClient client = new ExtendedWebClient())
            {
                try
                {
                    //requestData object represents any data you need to send to server
                    string data = JsonConvert.SerializeObject(
                                    requestData,
                                    new JsonSerializerSettings { ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver() });
                    client.Headers.Add("Content-Type", "application/json; charset=utf-8");
                    client.Encoding = System.Text.Encoding.UTF8;
                    string url = "http://yourdomain.com/api";
                    string response = client.UploadString(url, data);
                    //Deal with response as you need
                }
                catch (Exception ex)
                {
                    Console.Error.Write(ex.Message);
                }
            }
