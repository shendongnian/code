    public class MyControl : UserControl
    {
        ...
        public event EventHandler ShowSideBar;
        // Call this method when you need to show the side bar.
        public void OnShowSideBar()
        {
            var s = this.ShowSideBar;
            if (s != null)
            {
                s(this, EventArgs.Empty);
            }
        }
    }
    public class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            this.FirstControl.ShowSideBar += (s, e) =>
            {
                this.SecondControl.Visibility = Visibility.Visible;
            }
        }
    }
