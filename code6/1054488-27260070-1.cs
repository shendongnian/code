    public class Available
    {
        public double USD { get; set; }
    }
    
    public class FeeBracket
    {
        public string maker { get; set; }
        public string taker { get; set; }
    }
    
    public class BalancesAndInfo
    {
        public List<object> on_hold { get; set; }
        public Available available { get; set; }
        public string usd_volume { get; set; }
        public FeeBracket fee_bracket { get; set; }
        public string global_usd_volume { get; set; }
    }
    
    public class YourObject
    {
        public BalancesAndInfo balances_and_info { get; set; }
    }
