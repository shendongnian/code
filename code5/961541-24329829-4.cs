    public class MyRef<T> {
        public T Ref {get;set;}
    }
    public class Test1
    {
        Dictionary<string, object> MyDict = new Dictionary<string, object>();
    
        public void saveVar(string key, object v) 
        {
            MyDict.Add(key, v);
        }
        public void changeVar(string key, object newValue) //changing any of them
        {
            var ref1 = MyDict[key] as MyRef<int>;
            if (ref1 != null) {
                ref1.Ref = (int)newValue;
                return; // no sense in wasting cpu cycles
            }
            var ref2 = MyDict[key] as MyRef<string>;
            if (ref2 != null) {
                ref2.Ref = newValue.ToString();
            }
        }
        public void DoIt()
        {
            var v = new MyRef<int> { Ref = 1 };
            saveVar("First", v);
            changeVar("First", 2);
            Console.WriteLine(v.Ref.ToString()); // Should print 2
            Console.WriteLine(((MyRef<int>)MyDict["First"]).Ref.ToString()); // should also print 2
        }
    }
    
