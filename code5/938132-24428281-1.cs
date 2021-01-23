    public class VisualStudioWriter : IVisualStudioWriter
    {  
        private EnvDTE.OutputWindowPane _outputWindowPane;
        public VisualStudioWriter(DTE dte, System.IServiceProvider serviceProvider)
        {                      
            _outputWindowPane = LoadOutputWindowPane(dte);
        }
        private EnvDTE.OutputWindowPane LoadOutputWindowPane(DTE dte)
        {
            const string windowName = "pMixins Code Generator";
            EnvDTE.OutputWindowPane pane = null;
            EnvDTE.Window window = dte.Windows.Item(EnvDTE.Constants.vsWindowKindOutput);
            if (window != null)
            {
                EnvDTE.OutputWindow output = window.Object as EnvDTE.OutputWindow;
                if (output != null)
                {
                    pane = output.ActivePane;
                    if (pane == null || pane.Name != windowName)
                    {
                        for (int ix = output.OutputWindowPanes.Count; ix > 0; ix--)
                        {
                            pane = output.OutputWindowPanes.Item(ix);
                            if (pane.Name == windowName)
                                break;
                        }
                        if (pane == null || pane.Name != windowName)
                            pane = output.OutputWindowPanes.Add(windowName);
                        if (pane != null)
                            pane.Activate();
                    }
                }
            }
            return pane;
        }
        public void OutputString(string s)
        {
            _outputWindowPane.OutputString(s);
        }
     }
