        DateTime start = DateTime.Now;
        while (true)
        {
            
            if ((DateTime.Now - start ).TotalMilliseconds>500) // Is a timespan
              { break; }             
            Console.WriteLine(timeNow);
        }
