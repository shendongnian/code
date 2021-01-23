    public class MyDict: Dictionary<string,string>
    {
        public string this[string key]
        {
            get
            {
                 return base[key];
            }
            set
            {
                base[key] = value;
            }
        }
    }
