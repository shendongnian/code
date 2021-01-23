    public struct Data
    {
        public Data(int intValue, string strValue)
        {
            IntegerData = intValue;
            StringData = strValue;
        }
    
        public int IntegerData { get; private set; }
        public string StringData { get; private set; }
    }
    var list = new List<Data>();
