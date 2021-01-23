    [JsonConverter(typeof (CustomSerializer))]
    public struct CustomStruct
    {
        public int PublicInt;
        private int _privateInt;
        public string PublicString;
        private string _privateString;
        public int AutoInt { get; set; }
        public string AutoString { get; set; }
        public int ManualInt 
        {
            get{return _privateInt;}
            set { _privateInt = value; }
        }
        public string ManualString
        {
            get { return _privateString; }
            set { _privateString = value; }
        }
    }
    class Program
    {
        private static void Main(string[] args)
        {
            var obj = new CustomStruct()
            {
                AutoInt = 10,
                AutoString = "autostring",
                ManualInt = 5,
                ManualString = "manualstring",
                PublicInt = 20,
                PublicString = "publicstring"
            };
            var json = JsonConvert.SerializeObject(obj,Formatting.Indented);
            var dObj = JsonConvert.DeserializeObject<CustomStruct>(json);
        }
    }
