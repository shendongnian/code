      public void RunTest(Action action, String name, Int32 iterations)
      {
          var sw = new System.Diagnostics.Stopwatch();
          System.GC.Collect();
          System.GC.WaitForPendingFinalizers();
      
          sw.Start();
      
          for(var i = 0; i<iterations; i++)
          {
              action();
          }
      
          sw.Stop();
      
          Console.Write("Name: {0},", name);
          Console.Write(" Iterations: {1},", iterations);
          Console.WriteLine(" Milliseconds: {2}", sw.ElapsedMilliseconds);
      }
