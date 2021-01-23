    using System;
    
    class Program
    {
        static void Main(string[] args)
        {
            DateTime dt = DateTime.Now;
    
            bool condition = true;
    
            dynamic result = condition ?
                (object)new
                {
                    id = 1,
                    prop = dt
                }
                :
                (object)new
                {
                    id = 2,
                };
    
            Console.WriteLine(result.id);
            if (condition) Console.WriteLine(result.prop);
        }
    }
