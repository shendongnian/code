    public partial class MonthViewUserControl : UserControl
    {
        public MonthViewUserControl()
        {
            InitializeComponent();
        }
        public void loadGridSetup(DateTime dt)
        {
            TextBlock txt = new TextBlock();
            txt.Text = dt.ToShortDateString();
            txt.Tap += dayTap;
            (MonthViewGrid as Grid).Children.Add(txt);
        }
        void dayTap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            DateTime dt = (DateTime)((FrameworkElement)sender).DataContext;
            MonthView.CurrentPage.navigateBackToDay(dt);
        }
    }
