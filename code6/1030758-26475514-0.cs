    using System;
    using System.Collections.Generic;
    
    class Test
    {
        static void Main()
        {
            string[] array = new string[1];
            IList<string> list = array;
            Console.WriteLine(object.ReferenceEquals(array, list));
            Console.WriteLine(list.IsReadOnly);
            list[0] = "foo";
            Console.WriteLine(list[0]);
        }
    }
