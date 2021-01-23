    using System;
    using System.Reflection;
    class Program
    {
        static void Main()
        {
            Test t = new Test();
            Console.WriteLine(t.GetType().GetProperty("Id1").GetValue(t, null));
            Console.WriteLine(t.GetType().GetProperty("Id2").GetValue(t, null));
            Console.WriteLine(t.GetType().GetProperty("Id3").GetValue(t, null));
        
            //the next line will throw a NullReferenceExcption
            Console.WriteLine(t.GetType().GetProperty("Id4").GetValue(t, null));
            //this line will work
            Console.WriteLine(t.GetType().GetProperty("Id4",BindingFlags.Instance | BindingFlags.NonPublic).GetValue(t, null));
        
        
            //the next line will throw a NullReferenceException
            Console.WriteLine(t.GetType().GetProperty("Id5").GetValue(t, null));
             //this line will work
            Console.WriteLine(t.GetType().GetProperty("Id5", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(t, null));
        }
    
        public class Test
        {
            public Test()
            {
                Id1 = 1;
                Id2 = 2;
                Id3 = 3;
                Id4 = 4;
                Id5 = 5;
            }
        
            public int Id1 { get; set; }
            public int Id2 { private get; set; }
            public int Id3 { get; private set; }
            protected int Id4 { get; set; }
            private int Id5 { get; set; }
        }
    }
