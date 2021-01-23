    class Data
    {
        public string id { get; set; }
        public string type { get; set; }
        public string claims { get; set; }
    }
    var obj = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string,Data>>>(json);
    Data data = obj["entities"].FirstOrDefault().Value;
