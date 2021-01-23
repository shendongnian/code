    public static bool GenerateStack(StackSettings stackSettings, IProgress<FullOrder> progress = null)
    {
         for(var i = 0; i < 10; i++) 
         {
              // long, long request, replaced with:
              System.Threading.Thread.Sleep(10000);
              if (progress != null)
              {
                  progress.Report(order);
              }
          }
          return true;
    }
