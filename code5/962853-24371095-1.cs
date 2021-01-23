       PerformanceCounter counter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
       while (true)
       {
           float cpuPercent = counter.nextValue();
           if (cpuPercent >= 5)
           {
               totalhits += 1;
               if (totalhits == 10)
               {
                   Console.WriteLine("Alert Usage has exceeded");
                   Console.WriteLine("Press Enter to continue");
                   Console.ReadLine();
                   totalhits = 0;
               }
           }
           else
           {
               totalhits = 0;
           }
       }
  
