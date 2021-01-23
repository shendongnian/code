    long minValue = 10000000;
    string seed = "seed text";
    object lockObj = new Object();
    //Solution variables
    int iter = 0;
    object benchObj = new Object();
    DateTime lastBenchmark = DateTime.Now;
    Parallel.For(1, Int32.Max, (i, ls) =>
    {
      long val = DoCalcs(seed + i.ToString); //Assume that DoCalcs does some form of calculation.
      if (val < minValue)
      {
        lock (lockObj)
        {
          /* Write the value to a text file */
          Console.WriteLine("Found a smaller value ({0})!", minValue);
        }
      }
      //My version of benchmark output
      lock(benchObj)
      {
        iter++;
        if (lastBenchmark.AddSeconds(5) < DateTime.Now)
        {
           Console.WriteLine("Executing {0:F3} kCalcs/s!", ((float)iter) / 5 / 1000);
           iter = 0;
           lastBenchmark = DateTime.Now;
        }        
      }
    });
