     [Conditional("DEBUG")]
        public static void DebugPrintTrace()
        {
            StackTrace st = new StackTrace(true);
            StackFrame sf = st.GetFrame(1);
            Console.WriteLine("Trace "
                + sf.GetFileName() + " "
                + sf.GetMethod().Name + ":"
                + sf.GetFileLineNumber() + "\n");
        } 
