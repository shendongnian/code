    public sealed class MyExtensionPackage : Package
    {
        protected override void Initialize()
        {
            DTE dte = (DTE)base.GetService(typeof(DTE));
            var txtMgr = (IVsTextManager)base.GetService(typeof(SVsTextManager));
            plugin = new MyExtension(dte, txtMgr);
            base.Initialize();
        }
    }
    internal class MyExtension
        {
            private CommandEvents commandEvents;
    
            private DTE dte;
            private IVsTextManager txtMngr;
    
            public MyExtension(DTE dte, IVsTextManager txtMngr)
            {
                this.txtMngr = txtMngr;
                this.dte = dte;
                commandEvents = dte.Events.CommandEvents;
                commandEvents.BeforeExecute += commandEvents_BeforeExecute;
            }
    
            void commandEvents_BeforeExecute(string Guid, int ID, object CustomIn, object CustomOut, ref bool CancelDefault)
            {
                var doc = dte.ActiveDocument
                
                IVsTextView textViewCurrent;
                txtMngr.GetActiveView(1, null, out textViewCurrent);
                int a, b, c, verticalScrollPosition;
    
                var scrollInfo = textViewCurrent.GetScrollInfo(1, out a, out b, out c, out verticalScrollPosition);
                textViewCurrent.SetScrollPosition(1, verticalScrollPosition);
            }
        }
