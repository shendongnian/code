    var services = JsonConvert.DeserializeObject<List<Service>>(yourjson);
  
    public class Service
    {
        public string service_type { get; set; }
        public string price { get; set; }
        public string money_added { get; set; }
        public string value { get; set; }
        public string type { get; set; }
    }
