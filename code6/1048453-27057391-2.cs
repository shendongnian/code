    partial class SomeForm : Form
    {
        private TaskScheduler _uiSyncContext;
        public SomeForm()
        {
            _uiSyncContext = TaskScheduler.FromCurrentSynchronizationContext();
        }
    }
