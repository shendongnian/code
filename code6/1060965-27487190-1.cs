    public class WithIndexer
    {
        public object this[string keyName]
        {
            get
            {
                if (keyName == "key")
                {
                    return "I am a key";
                }
                return string.Empty;
            }
        }
        public object this[int keyName]
        {
            get
            {
                return "Item " + keyName.ToString();
            }
        }
        public object this[int keyName, string aString]
        {
            get
            {
                return aString + " item " + keyName;
            }
        }
        public WithIndexer()
        { 
        }
    }
