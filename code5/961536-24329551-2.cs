    class Test1
    {
        Dictionary<string, VariableReference> MyDict = new Dictionary<string, VariableReference>();
    
        public void saveVar(string key, Func<object> getter, Action<object> setter)
        {
            MyDict.Add(key, new VariableReference(getter, setter));
        }
    
        public void changeVar(string key) // changing any of them
        {
            if (MyDict[key].Get() is int)
            {
                MyDict[key].Set((int)MyDict[key].Get() * 2);
            }
            else if (MyDict[key].Get() is string)
            {
                MyDict[key].Set("Hello");
            }
        }
    }
    // ...
    Test1 t1 = new Test1();
    int myInt = 3;
    string myString = "defaultString";
    
    Console.WriteLine(myInt);    // prints "3"
    Console.WriteLine(myString); // prints "defaultString"
    
    t1.saveVar("key1", () => myInt, v => { myInt = (int) v; });
    t1.saveVar("key2", () => myString, v => { myString = (string) v; });
    
    t1.changeVar("key1");
    t1.changeVar("key2");
    
    Console.WriteLine(myInt);    // actually prints "6"
    Console.WriteLine(myString); // actually prints "Hello"
