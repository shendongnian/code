    try
    {   
        var error= Convert.ToInt32("fdafa"); 
    }
    catch(Exception ex)
    {
        StackTrace trace = new StackTrace(ex, true);
        string fileName = trace.GetFrame(trace.FrameCount - 1).GetFileName();
        int lineNo = trace.GetFrame(trace.FrameCount - 1).GetFileLineNumber(); 
    }
