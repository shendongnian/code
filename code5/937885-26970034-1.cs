    class MyAwesomeClass
    {
        public MyAwesomeClass()
        {
            SomeClassInPCL.myTracer.MessageWritten += TraceMessageAction;
        }
        public void TraceMessageAction(object sender, PclTraceWriteEventArgs args)
        {
            Trace.WriteLine(args.WrittenMessage);
        }
    }
