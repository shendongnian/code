       class Response
        {
        [JsonProperty(PropertyName = "response")]
        public dynamic Items { get; set; }
        }
        var des = JsonConvert.DeserializeObject<Response>(data);
        var result = (des.Items as IEnumerable<Newtonsoft.Json.Linq.JToken>)
                  .Select(delegate(JToken j){
            if (j.Type == JTokenType.Integer)
                return j.Value<int>();
            
            return JsonConvert.DeserializeObject<object>(j.ToString());
        }).ToList();
        var one = JsonConvert.DeserializeObject<Item>(result[1].ToString());
