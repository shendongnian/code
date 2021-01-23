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
            if (MyDict[key].GetType() == typeof(MyRef<int>))
            {
                ((MyRef<int>)MyDict[key]).Ref = (int)newValue;
            }
            if (MyDict[key].GetType() == typeof(MyRef<string>))
            {
                ((MyRef<string>)MyDict[key]).Ref = newValue.ToString();
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
    
