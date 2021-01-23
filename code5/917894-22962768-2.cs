    using System;
    
    class Test
    {
        static void Main()
        {
            int minutes = 31; 
            TimeSpan ts = TimeSpan.FromMinutes(minutes);
            string text = string.Format("{0}:{1:mm}", (int) ts.TotalHours, ts);
            Console.WriteLine(text); // 0:31
        }
    }
