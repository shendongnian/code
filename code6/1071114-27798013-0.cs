    class Helper : Settings
    {
        public Helper()
        {
           DeclineData = false;
           AcceptList = new List<string>();
        }
        public bool DeclineData { get; set; }
        public List<string> AcceptList { get; set; }
    }
