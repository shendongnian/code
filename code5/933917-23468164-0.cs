    using System;
    
    class Test
    {
        static void Main()
        {
            Show(0m);        // 0.00
            Show(0.123m);    // 0.12
            Show(123.456m);  // 123.46
            Show(-123.456m); // -123.46
        }
            
        static void Show(decimal value)
        {
            Console.WriteLine(value.ToString("0.00"));
        }
    }
