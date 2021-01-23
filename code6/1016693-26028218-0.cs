    internal class YahooContacts : IEnumerable<YahooContact>
    {
        public List<YahooContact> contact { get; set; }
        public int count { get; set; }
        public int start { get; set; }
        public int total { get; set; }
        public string uri { get; set; }
        public bool cache { get; set; }
        public IEnumerator<YahooContact> GetEnumerator()
        {
            return contact.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return contact.GetEnumerator();
        }
    }
