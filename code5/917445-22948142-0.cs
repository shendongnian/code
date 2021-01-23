      object readonly _cachedResultLock = new object();
      ...
      if (_cachedResult == null)
      {
         lock(_cachedResultLock)
         {
             if (_cachedResult == null)
             {
                 _cachedResult = new ExpensiveCalculation(arg);
             }
         }
       }
