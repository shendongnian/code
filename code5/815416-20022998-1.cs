    StackTrace trace = new StackTrace(System.Threading.Thread.CurrentThread, true);
    StackFrame[] frames = trace.GetFrames();
    string result = string.Empty;
    foreach (StackFrame sf in frames)
    {
      string += sf.GetMethod().Name;
    }
    MessageBox(result);
