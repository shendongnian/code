    class MyEntity
    {
        public MyEntity()
        {
            Data = new List<string>().Where(x => true);
        }
        public IEnumerable<string> Data { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string data = @"[{""Data"":[""a"",""b""]}]";
            var j = JsonConvert.DeserializeObject<IEnumerable<MyEntity>>(data);
        }
    }
