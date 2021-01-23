    public partial class ProgressWindow : Window
    {
        public ProgressWindow()
        {
            InitializeComponent();
            Querier.Start +=()=> Visibility = Visibility.Visible;
            Querier.Stop += () => Visibility = Visibility.Collapsed;
            Querier.ReportProgress +=OnReportProgress;
        }
        public void OnReportProgress(int value)
        {
            txtBox.Text = value.ToString();
        }
    }
