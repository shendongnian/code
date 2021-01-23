        public class MyCustomKey : ReadOnlyCollection<MyKey>
        {
            public override int GetHashCode()
            {
                return this.Aggregate(0, (c, i) => c + i.Name.GetHashCode()*i.Name.Length);
            }
            public override bool Equals(object obj)
            {
                var myKey = obj as MyCustomKey;
                if (myKey!= null && myKey.Count == this.Count)
                {
                    return myKey.Zip(this, (i, j) => i.Name == j.Name).All(i=>i);
                }
                return false;
            }
        }
        var dict = new Dictionary<MyCustomKey, Emp>();
        var key1 = new MyCustomKey(new[] {new MyKey {Name = "string1"}});
        dict.Add(key1, new Emp());
        var key2 = new MyCustomKey(new[] {new MyKey {Name = "string1"}});
        if (!dict.ContainsKey(key2))
        {
             dict.Add(key2, new Emp());
        }
