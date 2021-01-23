    internal class MainAppCxt : ApplicationContext
    {
        #region Singleton --- we need only one instance for this
        private static readonly object Mutex = new object();
        private static volatile MainAppCxt _instance;
    
        public static MainAppCxt Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Mutex)
                    {
                        if (_instance == null)
                            _instance = new MainAppCxt();
                    }
                }
                return _instance;
            }
        }
        #endregion
    
        public MainAppCxt()
        {
            ReplaceMainWindow(new Form1());
        }
    
        internal void ReplaceMainWindow(Form wnd)
        {
            var oldMainFrm = this.MainForm;
            this.MainForm = wnd;
            this.MainForm.Show();
            if (oldMainFrm != null && !oldMainFrm.IsDisposed)
                oldMainFrm.Close();
        }
    }
