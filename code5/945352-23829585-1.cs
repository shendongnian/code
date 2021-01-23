    using System.Diagnostics; 
    
    StackTrace stackTrace = new StackTrace();           // Get call stack
    StackFrame[] stackFrames = stackTrace.GetFrames();  // Get method calls (frames)
    
    // write call stack method names
    foreach (StackFrame stackFrame in stackFrames)
    {
        Console.WriteLine(stackFrame.GetMethod().Name); // Write method name
    }
