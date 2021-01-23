    public class Process
    {
        private class ParamsP
        {
            [JsonProperty("guId")]
            public string GroupId { get; set; }
        }
        private class BuildGetPlayers
        {
            [JsonProperty("json-rpc")]
            public string JsonRpc { get; set; }
            [JsonProperty("method")]
            public string Method { get; set; }
            [JsonProperty("params")]
            public ParamsP Params { get; set; }
            [JsonProperty("id")]
            public int Id { get; set; }
            [JsonProperty("version")]
            public string Version { get; set; }
        }
        BuildGetPlayers jRequest = new BuildGetPlayers
        {
            JsonRpc = "2.0",
            Method = "getThings",
            Params = new ParamsP
            {
                GroupId = "something"
            },
            Id = 1,
            Version = "1.0",
        };
        public string Get()
        {
            var httpRequest = JsonConvert.SerializeObject(jRequest, Formatting.Indented);
            return httpRequest;
            /* returns {
                  "json-rpc": "2.0",
                  "method": "getThings",
                  "params": {
                    "guId": "something"
                  },
                  "id": 1,
                  "version": "1.0"
                }
            */
        }
    }
