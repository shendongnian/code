	 public class MyObject
        {
            public static IMyCollection GetCollection()
            {
                var a = new List<MyObject>();
                a.Add(new MyObject());
                var b = new List<IReadOnlyList<MyObject>>();
                b.Add(a.AsReadOnly());
                return new MyCollectionImpl(b.AsReadOnly());
            }
        }
