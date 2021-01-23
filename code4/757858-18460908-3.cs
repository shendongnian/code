    public int NestedTask(IEnumerable<string> tierNodes)
    {
      int parentTimeout = 15 * 1000;
      int childTimeout = 3 * 1000;
  
      var tier = Task<int>.Factory.StartNew(() =>
      {
          foreach (var n in tierNodes)
          {
              var node = Task<int>.Factory.StartNew(() =>
              {
                  // Task logic goes here
                  return 1;
              });
  
              // If we get the result we return it, else we wait
              if (node.Wait(childTimeout))
                  return node.Result;
          }
          throw new Exception("did not get result!");
      });
  
      if (!tier.Wait(parentTimeout))
      {
          // The child will continue on running though.
          throw new TimeoutException("parent timed out");
      }
      else if (tier.Exception != null)
      {
          // We have an error
          throw tier.Exception.InnerException;
      }
  
      return tier.Result;
    }
