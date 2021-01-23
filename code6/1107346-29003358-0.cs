    using EnvDTE;
    using Microsoft.VisualStudio.Shell;
    private class MyClass
    {
        private DTE dte;
        public MyClass()
        {
            dte = Package.GetGlobalService(typeof(EnvDTE.DTE)) as EnvDTE.DTE;
            dte.Events.WindowEvents.WindowActivated += OnWindowActivated;
        }
        private void OnWindowActivated(Window gotFocus, Window lostFocus)
        {
            throw new NotImplementedException();
        }
    }
