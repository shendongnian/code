    using MongoDB.Bson;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    [HttpGet]
            public JObject Index()
            {
                StubClass c = new StubClass()
                {
                    Id = ObjectId.GenerateNewId()
                };
                JObject jobj = JObject.FromObject(c);
                return jobj;
            }
