    internal static void RedirectConsole()
    {
        mLog.Info("RedirectConsole called.");
        ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(InfoLogWriter));
        // TODO enqueue and item for error messages too.
    }
