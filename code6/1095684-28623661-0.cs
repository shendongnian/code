    public class ClsDictionary
    {
        private Dictionary<string, string> Details;
        public ClsDictionary()
        {
            Details = new Dictionary<string, string>();
        }
        public Dictionary<string, string> getDictionary()
        {
            return this.Details;
        }
        public bool AddDetail(string name, string value)
        {
            if (this.Details.ContainsKey(name))
            {
                return false;
            }
            this.Details.Add(name, value);
            return true;
        }
    }
