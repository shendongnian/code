        var dict = new Dictionary<List<MyKey>, Emp>(new MyCustomComparer());
        var key1 = new List<MyKey>
                       {
                           {new MyKey{ Name = "string1"}}
                       };
        dict.Add(key1, new Emp());
        var key2 = new List<MyKey>
                       {
                           {new MyKey{ Name = "string1"}}
                       };
        if (!dict.ContainsKey(key2))
        {
            dict.Add(key2, new Emp());
        }
    public class MyKey
    {
        public string Name { get; set; }
    
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    
        public override bool Equals(object obj)
        {
            var myKey = obj as MyKey;
            if (myKey != null)
            {
                return Name == myKey.Name;
            }
            return false;
        }
    }
    
    public class Emp
    {
    }
