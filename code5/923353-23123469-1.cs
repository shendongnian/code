    public static class ServicesHelper
        {
            public static void SendJson(HttpResponse response, object data)
            {
                var serializer = new JsonSerializer();
                //serializer.Converters.Add(new JavaScriptDateTimeConverter());
                response.ClearContent();
                response.ContentType = "application/json";
                using (var sw = new StreamWriter(response.OutputStream))
                {
                    using (var writer = new JsonTextWriter(sw))
                    {
                        serializer.Serialize(writer, data);
                    }
                }
            }
    
            public static string ToJson(object data)
            {
                return JsonConvert.SerializeObject(data);
            }
        }
