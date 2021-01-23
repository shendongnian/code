    static class Program
    {
        static void Main()
        {
            P p = new P { T = new T { a = 123, b = 456 } },
                clone;
            using (var ms = new MemoryStream())
            {
                Serializer.Serialize(ms, p);
                ms.Position = 0;
                clone = Serializer.Deserialize<P>(ms);
            }
            System.Console.WriteLine(clone.T.a); // 123
            System.Console.WriteLine(clone.T.b); // 456
        }
    }
