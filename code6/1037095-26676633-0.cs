    public partial class SinglePlayerSummaryView : UserControl
    {
        public SinglePlayerSummaryView()
        {
            InitializeComponent();
    
           #if ReleaseStandard
                this.Check.Visibility = System.Windows.Visibility.Visible;
           #else
                this. Check.Visibility = System.Windows.Visibility.Hidden;
           #endif
        }
    }
