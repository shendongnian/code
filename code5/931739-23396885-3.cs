    using System;
    
    class Test
    {
        static void Main()
        {
            DateTime start = DateTime.UtcNow;
            Show(DateTime.SpecifyKind(start, DateTimeKind.Utc));
            Show(DateTime.SpecifyKind(start, DateTimeKind.Local));
            Show(DateTime.SpecifyKind(start, DateTimeKind.Unspecified));
        }
        
        static void Show(DateTime dt)
        {
            Console.WriteLine(dt.Kind);
            DateTime dt2 = DateTime.FromBinary(dt.ToBinary());
            Console.WriteLine(dt2.Kind);
            Console.WriteLine("===");
        }
    }
