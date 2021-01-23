    public class Test
    {
        private string _myProperty = string.Empty;
        [JsonProperty(PropertyName = "myProperty")]
        public string MyProperty
        {
            get { return _myProperty; }
            set { _myProperty = value; }
        }
    }
