    public class MyRef<T> {
        T Ref {get;set;}
    }
    class Test1
    {
        var MyDict = new Dictionary<string, object>();
    
        public void saveVar(string key, object) 
        {
            MyDict.Add(key, v);
        }
        public void changeVar(string key, object newValue) //changing any of them
        {
            if (MyDict[key].Ref.GetType() == typeof(int))
            {
                MyDict[key].Ref = (int)newValue;
            }
            if (MyDict[key].Ref.GetType() == typeof(string))
            {
                MyDict[key].Ref = newValue.ToString();
            }
        }
        public void DoIt()
        {
            var v = new MyRef<int> { Ref = 1 }
            saveVar("First", v)
            
            changeVar("First", 2)
            Console.WriteLine(v.Ref.ToString()); // Should print 2
        }
    }
    
