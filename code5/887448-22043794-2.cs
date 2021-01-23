    using System.Collections.Generic;
    namespace App
    {
        class Program
        {
            class Example
            {
                List<string> list = new List<string> { "a", "b", "c" };
    
                public IEnumerable<string> AsEnumerable()
                {
                    return list;
                }
            }
    
            static void Main(string[] args)
            {
                IEnumerable<string> foo = new Example().AsEnumerable();
                List<string> bar = (List<string>)foo;
            }
        }
    }
