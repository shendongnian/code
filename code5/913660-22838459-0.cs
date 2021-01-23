    Newtonsoft.Json.JsonConvert.DeserializeObject<JSON>(s);
        public class JSON
        {
            [JsonProperty(PropertyName = "getappdata")]
            public GetAppData getappdata { get; set; }
		}
        [Serializable]
        public class General
        {
	       [JsonProperty(PropertyName = "message")]
           public string msg { get; set; }
	    }
       [Serializable]
       public class GetAppData
       {
           [JsonProperty(PropertyName = "general")]
           public General general { get; set; }
           [JsonProperty(PropertyName = "pool")]
           public Pool pool { get; set; }
           [JsonProperty(PropertyName = "ltc_exchange_rates")]
           public Erates erates { get; set; }
           [JsonProperty(PropertyName = "user")]
           public User user { get; set; }
           [JsonProperty(PropertyName = "worker")]
           public IList<Worker> workers { get; set; }
           [JsonProperty(PropertyName = "earnings")]
           public Earnings earnings { get; set; }
       }
       [Serializable]                
       public class Msg
       {
           public string msg { get; set; }
          
       }
       [Serializable]
       public class Pool
       {
           [JsonProperty(PropertyName = "hashrate")]
           public int hashrate { get; set; }
           [JsonProperty(PropertyName = "workers")]
           public int Workers { get; set; }
           [JsonProperty(PropertyName = "basis_pps")]
           public double basis_pps { get; set; }
           [JsonProperty(PropertyName = "alt_pps")]
           public double alt_pps { get; set; }
           [JsonProperty(PropertyName = "alt_bonus")]
           public double alt_bonus { get; set; }
       }
       [Serializable]
       public class Erates
       {
           [JsonProperty(PropertyName = "USD")]
           public double USD { get; set; }
           [JsonProperty(PropertyName = "EUR")]
           public double EUR { get; set; }
          
       }
       [Serializable]
       public class User
       {
           [JsonProperty(PropertyName = "username")]
           public string Username { get; set; }
           [JsonProperty(PropertyName = "balance")]
           public double Balance { get; set; }
           [JsonProperty(PropertyName = "hashrate")]
           public double Hashrate { get; set; }
           [JsonProperty(PropertyName = "sharerate")]
           public double Sharerate { get; set; }
           [JsonProperty(PropertyName = "invalid_share_rate")]
           public double Invalid_Share_Rates { get; set; }
          
       }
       [Serializable]
       public class Worker
       {
           [JsonProperty(PropertyName = "name")]
           public string Name { get; set; }
           [JsonProperty(PropertyName = "hashrate")]
           public int hashrate { get; set; }
           [JsonProperty(PropertyName = "active")]
           public string active { get; set; }
           [JsonProperty(PropertyName = "monitoring")]
           public string monitoring { get; set; }
         
       }
       [Serializable]
       public class Earnings
       {
           [JsonProperty(PropertyName = "basis")]
           public IList<string> basis { get; set; }
           [JsonProperty(PropertyName = "alt")]
           public IList<string> alt { get; set; }
           [JsonProperty(PropertyName = "24h_total")]
           public string DayTotal { get; set; }
           [JsonProperty(PropertyName = "24h_basis")]
           public string DayBasis { get; set; }
           [JsonProperty(PropertyName = "24h_alt")]
           public string DayAlt { get; set; }
           [JsonProperty(PropertyName = "24h_affiliate")]
           public string DayAffiliate { get; set; }
           [JsonProperty(PropertyName = "48h_total")]
           public string TwoDaysTotal { get; set; }
           [JsonProperty(PropertyName = "48h_basis")]
           public string TwoDaysBasis { get; set; }
           [JsonProperty(PropertyName = "48h_alt")]
           public string TwoDaysAlt { get; set; }
           [JsonProperty(PropertyName = "48h_affiliate")]
           public string TwoDaysAffiliate { get; set; }
         
       }
