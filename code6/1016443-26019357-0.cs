       object lockObj = new object(); // at class level
 
       private void EventWhereISetGlobalVariable ...
       {
         lock(lockObj)
         {
           _variableIneed = null;
           // some long and convoluted computations
           _variableIneed = someResult;
         }
       }
       private void EventWhereINeedTheGlobalVariableLater(object sender, Event e)
       {
         lock(lockObj)
         {
          // unsing _variableIneed 
         }
       }
