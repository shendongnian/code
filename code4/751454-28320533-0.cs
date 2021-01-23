    public class AdAccount
    {
        public long account_id { get; set; }
        public string currency { get; set; }
        private List<int> _capabilities;
        public List<int> capabilities
        {
            get { return _capabilities; }
            set { _capabilities = value; this.ParsedCapabilities = string.Join(",", value); }
        }
        public string ParsedCapabilities { get; set; }
    }
