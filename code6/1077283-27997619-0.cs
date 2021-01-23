    static void Main(string[] args)
    {
        try
        {
            CallForException();
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception occurred calling {0} method", GetCallForExceptionThisMethod(MethodBase.GetCurrentMethod(), e));
        }
    }
    private static string GetCallForExceptionThisMethod(MethodBase methodBase, Exception e)
    {
        StackTrace trace = new StackTrace(e);
        StackFrame previousFrame = null;
        foreach (StackFrame frame in trace.GetFrames())
        {
            if (frame.GetMethod() == methodBase)
            {
                break;
            }
            previousFrame = frame;
        }
        return previousFrame != null ? previousFrame.GetMethod().Name : null;
    }
    private static void CallForException()
    {
        DoActualException();
    }
    private static void DoActualException()
    {
        throw new NotImplementedException();
    }
