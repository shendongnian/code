    public class Setting
    {
        private readonly string _description;
        public string Name { get; private set; }
        public Setting(string name, string description)
        {
            Name = name;
            _description = description;
        }
        public string Value { get; set; }
        public string Description
        {
            get { return string.Format("{0}: {1}", Name, _description); }
        }
        public bool IsSet
        {
            get { return Value != null; }
        }
    }
