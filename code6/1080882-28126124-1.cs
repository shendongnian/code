    public partial class MainWindow : Window
    {
        GetScrollingText scrolling = new GetScrollingText();
        public MainWindow()
        {
            InitializeComponent();
            scrolling.scrollBlock = this.ScrollBlock;
            scrolling.LeftToRightMarqee(2000, -3000);
            DataContext = scrolling; // here
        }
    }
