    public class Base
    {
        static internal readonly Dictionary<System.Type, int> TypeMap =
           new Dictionary<System.Type, int>();
    }
    
    public class Foo : Base
    {
        static Foo { TypeMap.Add(typeof(Foo), 0); }
    }
    
    public class Bar : Base
    {
        static Bar { TypeMap.Add(typeof(Bar), 1); }
    }
    
    public static void printType(Base b)
    {
         Console.WriteLine(Base.TypeMap[b.GetType()]);
    }
