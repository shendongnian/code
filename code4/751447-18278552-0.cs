    public class AdAccount
    {
        public long account_id { get; set; }
        public string currency { get; set; }
        public List<int> capabilities { get; set; }
        public string capabilitiesDisplay
        {
            get
            {
                return string.Join(", ", capabilities);
            }
        }
    }
