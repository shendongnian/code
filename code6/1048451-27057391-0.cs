    partial class SomeForm : Form
    {
        private SynchronizationContext _uiSyncContext;
        public SomeForm()
        {
            _uiSyncContext = TaskScheduler.FromCurrentSynchronizationContext();
        }
    }
