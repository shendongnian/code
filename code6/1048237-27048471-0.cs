    public class Responses
    {
        [JsonIgnore]
        public List<Model> Model { get; set; }
        [JsonProperty(PropertyName = "ns1.model")]
        public JRaw ModelRaw
        {
            get { return new JRaw(JsonConvert.SerializeObject(Model)); }
            set
            {
                var raw = value.ToString(Formatting.None);
                Model = raw.StartsWith("[")
                    ? JsonConvert.DeserializeObject<List<Model>>(raw)
                    : new List<Model> { JsonConvert.DeserializeObject<Model>(raw) };
            }
        }
    }
