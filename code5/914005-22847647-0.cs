    public class WrapperDictionary
    {
        private Dictionary<int, Type> dictionary;
        public WrapperDictionary()
        {
            dictionary = new Dictionary<int, Type>();
        }
        public bool Add(int key, Type value)
        {
            if (!dictionary.ContainsKey(key) &&
                value.IsAssignableFrom(typeof (IRegistrationMethod)))
            {
                dictionary.Add(key, value);
                return true;
            }
            else return false;
        }
        public Type this[int key]
        {
            get
            {
                if (dictionary.ContainsKey(key)) return dictionary[key];
                 /* throw exception or return null */
            }
        }
    }
