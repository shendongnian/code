    // the local utc offset is  +2:00
     public class Program
    {
        public static void Main(string[] args)
        {
           // code executed in timezone GMT+2:00
            long ticksUtc = DateTime.UtcNow.Ticks;
            
            Console.WriteLine("{0:d}",ticksUtc);
            DateTime _todayUtc = new DateTime(ticksUtc);
             Console.WriteLine("{0}",_todayUtc);
            // get local date time from Utc time
             Console.WriteLine("{0}",_todayUtc.ToLocalTime());
            Console.WriteLine();
            long ticksLocal = DateTime.Now.Ticks;
            Console.WriteLine("{0:d}",ticksLocal);
            Console.WriteLine("{0:d}",ticksLocal-ticksUtc);
           DateTime _todayLocal = new DateTime(ticksLocal);
             Console.WriteLine("{0}",_todayLocal);
            
            // get the utc time from _todaylocal time
            Console.WriteLine("{0}",_todayLocal.ToUniversalTime());
        }
    }
