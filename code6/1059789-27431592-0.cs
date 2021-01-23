    public class Component
    {
        public string Name { get; set; }
        public Dictionary<string, object> Parameters { get; set; }
        public object this[string key]
        {
            get
            {
                return this.Parameters[key];
            }
            set
            {
                if(this.Parameters.ContainsKey(key))
                {
                    this.Parameters[key] = value;
                }
                else
                {
                    this.Parameters.Add(key, value);
                }
            }
        }
    }
