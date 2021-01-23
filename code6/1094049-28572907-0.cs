    internal class Functions
    {
         internal Functions(Object lockOnMe, List<AccEntry> results)
         {
              _lockOnMe = lockOnMe;
              _results = results;
              _result = new List<AccEntry>();
         }
         private object _lockOnMe;
         private List<AccEntry> _results;
         private List<AccEntry> _result;
    
         internal void SomeFunction()
         {
              /// some time consuming process that builds _result
              lock(_lockOnMe)
              {
                  _results.AddRange(_result);
              }
         }
    }
