    System.Diagnostics.EventLog eventLog = new System.Diagnostics.EventLog("System", ".", "Resource-Exhaustion-Detector");
    eventLog.EnableRaisingEvents = true;
    eventLog.EntryWritten += eventLog_EntryWritten;
    static void eventLog_EntryWritten(object sender, System.Diagnostics.EntryWrittenEventArgs e)
    {
       if (e.Entry.Message.Contains(Path.GetFileName(Process.GetCurrentProcess().MainModule.FileName)))
       {
          Logger.Error("Our application consumed too much memory `{0}`. So we stopping work right now to prevent reboot OS.", new object[] {e.Entry.Message},MethodBase.GetCurrentMethod());
          GC.Collect();
          //do smth                
       }
    }
