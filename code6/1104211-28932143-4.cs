    0:004> ~3e!pe
    Exception object: 0000000002786090
    Exception type: System.ArgumentException
    Message: This method does not have arguments.
    InnerException: <none>
    StackTrace (generated):
        SP               IP               Function
        000000000112F100 000007FF0017055F MultiException!MultiException.Program.ThrowException1()+0x5f
        000000000112F140 000007FEEB4E2BBC mscorlib_ni!System.Threading.ExecutionContext.Run(System.Threading.ExecutionContext, System.Threading.ContextCallback, System.Object)+0x9c
        000000000112F190 000007FEEB57AADE mscorlib_ni!System.Threading.ThreadHelper.ThreadStart()+0x4e
    
    StackTraceString: <none>
    HResult: 80070057
    0:004> ~4e!pe
    Exception object: 000000000278a070
    Exception type: System.NotImplementedException
    Message: This method does nothing but thorwing this exception.
    InnerException: <none>
    StackTrace (generated):
        SP               IP               Function
        000000000135F2C0 000007FF0017067F MultiException!MultiException.Program.ThrowException2()+0x5f
        000000000135F300 000007FEEB4E2BBC mscorlib_ni!System.Threading.ExecutionContext.Run(System.Threading.ExecutionContext, System.Threading.ContextCallback, System.Object)+0x9c
        000000000135F350 000007FEEB57AADE mscorlib_ni!System.Threading.ThreadHelper.ThreadStart()+0x4e
    
    StackTraceString: <none>
    HResult: 80004001
