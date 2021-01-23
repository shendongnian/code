    var obj = JsonConvert.DeserializeObject<Price>(json);
..
    public class Price
    {
        public Dictionary<string, Dictionary<string, string>> Prices { set; get; }
    }
