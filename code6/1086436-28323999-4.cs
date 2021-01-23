    public partial class ProgressForm: Form
    {
        public ProgressForm(Action action)
        {
            _action = action;
            InitializeComponent();
        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            Task.Factory.StartNew(() =>
            {
                _action();
                _finished = true;
                BeginInvoke(new Action(Close));
            });
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            // Prevent the user from closing the form until the action has completed.
            if (!_finished)
                e.Cancel = true;
        }
        private readonly Action _action;
        private volatile bool _finished;
    }
