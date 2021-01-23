    using System.Collections.Generic;
         
    public class Test
    {
        internal class Program
        {
            public static void Main()
            {
                var item = new Foo();
                var inner = new List<Foo>();
                var outer = new List<List<Foo>>();
    
                inner.Add(item);
                outer.Add(inner);
    
                IEnumerable<IEnumerable<Foo>> data = outer;
    
                foreach (Foo foo in data)
                {
                    foo.Bar();
                }
            }
    
        }
    
    
        public class Foo
        {
            public void Bar()
            {
            }
        }
    }
