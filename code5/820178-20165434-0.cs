    public class Row
    {
        [JsonProperty("key")]
        private string _key;
        [JsonIgnore]
        public string Key
        {
            get { return Base64Converter.ToUTF8(_key); }
            set { _key = value; }
        }
        [JsonProperty(PropertyName = "Cell")]
        public List<Cell> Cells { get; set; }
    }
    public class Cell
    {
        [JsonProperty(PropertyName = "column")]
        private string _column;
        [JsonIgnore]
        public string Column
        {
            get { return Base64Converter.ToUTF8(_column); }
            set { _column = value; }
        }
        [JsonProperty(PropertyName = "timestamp")]
        public string Timestamp { get; set; }
        [JsonProperty(PropertyName = "$")]
        private string _value;
        [JsonIgnore]
        public string Value
        {
            get { return Base64Converter.ToUTF8(_value); }
            set { _value = value; }
        }
    }
