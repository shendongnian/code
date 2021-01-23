    using System;
    public class EvilClass
    {
        public new Type GetType()
        {
            return typeof(IDisposable);
        }
    }
    class Test
    {
        static void Main()
        {
            EvilClass obj = new EvilClass();
            Console.WriteLine(obj.GetType().IsInterface); // True
        }
    }
