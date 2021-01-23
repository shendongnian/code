    public class ResourceDictionary : DynamicObject
    {
        private Dictionary<string, string> dictionary;
    
        public ResourceDictionary()
        {
            dictionary = new Dictionary<string, string>();
        }
    
        public void Add(string key, string value)
        {
            dictionary.Add(key, value);
        }
    
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            string data;
            if (!dictionary.TryGetValue(binder.Name, out data))
            {
                throw new KeyNotFoundException("Key not found!");
            }
    
            result = (string)data;
    
            return true;
        }
    
        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            if (dictionary.ContainsKey(binder.Name))
            {
                dictionary[binder.Name] = (string)value;
            }
            else
            {
                dictionary.Add(binder.Name, (string)value);
            }
    
            return true;
        }
    }
