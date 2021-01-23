    using System;
    
    class Test
    {
        public static bool operator ==(Test t, string x)
        {
            Console.WriteLine("Test == string");
            return false;
        }
    
        public static bool operator !=(Test t, string x)
        {
            Console.WriteLine("Test != string");
            return false;
        }
    
        public static bool operator ==(string x, Test t)
        {
            Console.WriteLine("string == Test");
            return false;
        }
    
        public static bool operator !=(string x, Test t)
        {
            Console.WriteLine("string != Test");
            return false;
        }
    
        static void Main(string[] args)
        {
            Test t = null;
            Console.WriteLine(t == null);
            Console.WriteLine(null == t);
        }
    }
