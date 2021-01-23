    public class RootObject
    {
        public int code { get; set; }
        public string message { get; set; }
        public Invoice invoice { get; set; }
    }
    Invoice ret = JsonConvert.DeserializeObject<RootObject>(results.Content).invoice;
