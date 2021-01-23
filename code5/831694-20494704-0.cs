    class Program
    {
        static void Main(string[] args)
        {
            DateTime uptime = new DateTime (2013,12,10,4,0,0);
            Console.WriteLine("This alarm is set to go off at 4:00 am");
            while (true)
            {
                if (DateTime.Now.Minute == uptime.Minute && DateTime.Now.Hour == uptime.Hour)
                {
                    for (int j = 1000; j < 22767; j++)
                     {
                        Console.Beep(j, 500);
                        Console.Write("Wake up! it is {0}:{1} already! ", DateTime.Now.Hour, DateTime.Now.Minute);
                     }                     
                }
                Thread.Sleep(1500); // Sleep 1.5 seconds.
             }
        }
    }
