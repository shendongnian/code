    var url = "http://data.mtgox.com/api/2/BTCUSD/money/ticker";
    HttpClient client = new HttpClient();
    var resp = await client.GetAsync(url);
    var obj = await resp.Content.ReadAsJson<Ticker.RootObject>();
.
    public class Ticker
    {
        public class Value
        {
            public string value { get; set; }
            public string value_int { get; set; }
            public string display { get; set; }
            public string display_short { get; set; }
            public string currency { get; set; }
        }
        public class Data
        {
            public Value high { get; set; }
            public Value low { get; set; }
            public Value avg { get; set; }
            public Value vwap { get; set; }
            public Value vol { get; set; }
            public Value last_local { get; set; }
            public Value last_orig { get; set; }
            public Value last_all { get; set; }
            public Value last { get; set; }
            public Value buy { get; set; }
            public Value sell { get; set; }
            public string item { get; set; }
            public string now { get; set; }
        }
        public class RootObject
        {
            public string result { get; set; }
            public Data data { get; set; }
        }
    }
