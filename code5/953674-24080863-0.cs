        try
        {
        //somecode
        }
        catch (Exception e)
        {
         Console.WriteLine("Error trace {0}", e.Trace);
         Console.WriteLine ("Inner Exception is {0}",e.InnerException);
        }
