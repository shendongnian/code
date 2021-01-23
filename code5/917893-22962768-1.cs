    using System;
    
    class Test
    {
        static void Main()
        {
            int minutes = 31; 
            TimeSpan ts = TimeSpan.FromMinutes(minutes);
            string text = ts.ToString("h':'mm");
            Console.WriteLine(text); // 0:31
        }
    }
