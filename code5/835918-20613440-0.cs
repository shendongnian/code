    this.DispatcherUnhandledException += new DispatcherUnhandledExceptionEventHandler(App_DispatcherUnhandledException);
    
    if (!string.IsNullOrEmpty(e.Exception.StackTrace))
    {
       sb.AppendLine("e.Exception.StackTrace ");
       int count = 0;
       foreach (string line in e.Exception.StackTrace.Split('\n'))
       {
           sb.AppendLine(line.Trim());
           count++;
           if (count > 10) break;
       }
    }
