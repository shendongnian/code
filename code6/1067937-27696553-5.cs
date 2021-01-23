    class MyDictionary : Dictionary<string, IMyInterface<ISomething>>
    {
        public void Add(string key, MyClass1 value)
        {
            base.Add(key, (IMyInterface<ISomething>)value);
        }
    
        public void Add(string key, MyClass2 value)
        {
            base.Add(key, (IMyInterface<ISomething>)value);
        }
    }
    var dic2 = new MyDictionary();
    dic2.Add("MyClass1", new MyClass1());
    dic2.Add("MyClass2", new MyClass2());
