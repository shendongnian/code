    public partial class LoggingButton : Button
    {
        public LoggingButton()
        {
            InitializeComponent();
        }
        protected override void OnClick(EventArgs e)
        {
            ClickLogger.NotifyClick(this);
            base.OnClick(e);
        }
    }
