        public SyncForm()
        {
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
        }
        private void SyncForm_Closed(object sender, EventArgs e)
        {
            someResource.Dispose();
        }
        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            someResource.Dispose();
        }
