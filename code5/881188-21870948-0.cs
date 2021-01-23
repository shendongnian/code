     public static void DoSomething()
            {
                try
                {
                    throw new InvalidOperationException("Exception");
                }
                catch (Exception e)
                {
                    StackTrace stackTrace = new StackTrace();
    
                    StackFrame stackFrame = stackTrace.GetFrame(0);
    
                    Console.WriteLine("Class Name: {0}, Method Name: {1}", stackFrame.GetMethod().Module, stackFrame.GetMethod().Name);
    
    
                }
            }
