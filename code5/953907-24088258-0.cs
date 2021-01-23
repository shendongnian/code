    Webclient wc = new Webclient();
    var json = wc.DownloadString("http://www.whattomine.com/coins.json"); //your 2nd link
    var coins = JsonConvert.DeserializeObject<Coins>(json);
---
    public class Coins
    {
        public Dictionary<string, Coin> coins = null;
    }
    public class Coin
    {
        public string tag { get; set; }
        public string algorithm { get; set; }
        public double block_reward { get; set; }
        public int block_time { get; set; }
        public int last_block { get; set; }
        public double difficulty { get; set; }
        public double difficulty24 { get; set; }
        public double nethash { get; set; }
        public double exchange_rate { get; set; }
        public string market_cap { get; set; }
        public double volume { get; set; }
        public int profitability { get; set; }
        public int profitability24 { get; set; }
    }
