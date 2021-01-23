     bool  IsInRecursion(string methodName) 
     {
       const int iCallDeepness = 1; 
       System.Diagnostics.StackTrace stack = new System.Diagnostics.StackTrace(false);
       System.Diagnostics.StackFrame sframe = stack.GetFrame(iCallDeepness);
       return (methodName == sframe.GetMethod().Name);
     }
