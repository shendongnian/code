    public class Accounts
    {
        private readonly List<Accounts> accounts;
        public Accounts()
        {
            accounts = new List<Accounts>();
        }
        public bool IsNodeExpanded { get; set; }
        public string Header { get; set; }
        public Brush Foreground { get; set; }
        public Brush Background { get; set; }
        public FontWeight FontWeight { get; set; }
        public string Parent { get; set; }
        public bool IsReadOnly { get; set; }
        public List<Accounts> Account
        {
            get { return accounts; }
        }
    
    }
