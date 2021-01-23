    class objDict : Dictionary<object, object>
    {
        // __init__
        public objDict(IDictionary obj = null)
        {
            if (obj == null)
            {
                return;
            }
            foreach (DictionaryEntry kv in obj)
            {
                if (kv.Value is IDictionary)
                {
                    // Not sure if it should be CultureInfo.InvariantCulture or CultureInfo.CurrentCulture
                    this.Add(CultureInfo.InvariantCulture.TextInfo.ToTitleCase(kv.Key.ToString()), new objDict((IDictionary)kv.Value));
                }
                else
                {
                    this.Add(kv.Key, kv.Value);
                }
            }
        }
        // __getitem__
        public object this[object key]
        {
            get
            {
                return this[key];
            }
        }
        // __repr__
        public string ToString()
        {
            return string.Join(", ", this.Select(p => string.Format("{0} : {0}", p.Key, p.Value)));
        }
    }
