    public class bar
    {
       public bar(list<int> id, String x, int size, byte[] bytes)
       {
         ...
       }
    }
    
    public class Foo: Bar
    {
        public Foo(list<int> id, String x, someEnumType y):
         base(id, x, sizeof(someEnumType), Convert(y))
        {
            //some functionality
        }
        public static byte[] Convert(SomeEnumType type)
        {
            // do convert
        }
    }
