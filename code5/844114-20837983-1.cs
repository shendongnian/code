    try
    {
        //Exception
        throw new Exception("An error has happened");
    }
    catch (Exception ex)
    {
         //Open the trace
         System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
         //Write out the error information, you could also do this with a string.Format 
         as I will post lower
         Console.WriteLine(trace.GetFrame(0).GetMethod().ReflectedType.FullName);
         Console.WriteLine("Line: " + trace.GetFrame(0).GetFileLineNumber());
         Console.WriteLine("Column: " + trace.GetFrame(0).GetFileColumnNumber());
    }
