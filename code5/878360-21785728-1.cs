    var obj = JsonConvert.DeserializeObject<Price>(json);
    Console.WriteLine(obj.Prices["SharedMinPrice"]["USD"]);
..
    public class Price
    {
        public Dictionary<string, Dictionary<string, string>> Prices { set; get; }
    }
