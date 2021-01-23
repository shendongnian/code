        RpcResponse rspResponse = JsonConvert.DeserializeObject<RpcResponse>(
            rspString, 
            new JsonSerializerSettings {
                DateParseHandling = Newtonsoft.Json.DateParseHandling.None,
                Converters = new List<JsonConverter>( new JsonConverter[] {
                        new RpcResponseResultConverter()
                        })
                });
