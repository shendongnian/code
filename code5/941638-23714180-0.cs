    class Program
    {
        static void Main(string[] args)
        {
            var json = "{\"Data\":{\"A1\":{\"name\":\"\",\"code\":\"\",\"type\":\"\"},\"A2\":{\"name\":\"\",\"code\":\"\",\"type\":\"\"},\"A3\":{\"name\":\"\",\"code\":\"\",\"type\":\"\"}}}";
            var data = (JsonConvert.DeserializeObject(json) as Newtonsoft.Json.Linq.JObject).First.First;
            List<DataItem> list = new List<DataItem>();
            foreach (var item in data.ToList())
            {
                list.Add(new DataItem()
                {
                    Name = ((Newtonsoft.Json.Linq.JProperty)(item)).Name,
                    A = JsonConvert.DeserializeObject<A>(item.First.ToString())
                });
            }
        }
        class DataItem
        {
            public string Name { get; set; } //A1, A2, A3 ....
            public A A { get; set; }
        }
        class A
        {
            public string name { get; set; }
            public string code { get; set; }
            public string type { get; set; }
        }
    }
