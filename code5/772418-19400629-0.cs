    public void ExampleMethod()
    {           
        SmartLog.EnterMethod("ExampleMethod()"); 
        try
        {
            SmartLog.Write("Some code happening before the loop");
            Guid exampleLoopID = SmartLog.RegisterLoop("exampleLoopID");
            for (int i = 0; i < 10; i++)
            {
                SmartLog.IncrementLoop(exampleLoopID);
                SmartLog.Write("Some code happening inside the loop.");
            }
            SmartLog.CompleteLoop(exampleLoopID);
            SmartLog.Write("Some code happening after the loop.");
            SmartLog.LeaveMethod("ExampleMethod()");
        }
        catch (Exception ex)
        {
            SmartLog.WriteException(ex);
            SmartLog.LeaveMethod("ExampleMethod()");
            throw;
        }
    }
