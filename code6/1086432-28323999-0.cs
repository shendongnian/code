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
            this.BeginInvoke(new Action(() =>
            {
                _action();
                this.Close();
            }));
        }
        private readonly Action _action;
    }
