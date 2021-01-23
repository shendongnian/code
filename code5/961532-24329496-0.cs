    class Test1
    {
        IDictionary<string, Pointer> MyDict = new Dictionary<string, Pointer>();
        public void saveVar(string key, Pointer pointer) //storing the ref to an int
        {
            MyDict.Add(key, pointer);
        }
        public void changeVar(string key) //changing any of them
        {
            if (MyDict.GetType() == typeof(int))
            {
                MyDict[key].Value = (int)(MyDict[key].Value) * 2;
            }
            if (MyDict.GetType() == typeof(string))
            {
                MyDict[key].Value = "Hello";
            }
        }
    }
