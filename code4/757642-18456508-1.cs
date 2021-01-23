    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
            pageViewDocText = new PageViewDocText();
            framePageDocFieldDetail.Content = pageViewDocText;
            pageViewDocText.PageBreakNext += new PageBreakNext(ViewIPRO);
        }
        protected void ViewIPRO(string IRPOlink) // ...
    }
    public partial class PageViewDocText : Page, INotifyPropertyChanged
    {
        public delegate void PageBreakNext(string IRPOlink);
        public event PageBreakNext PageBreak;
        private void btn_PageBreakNext(object sender, RoutedEventArgs e)
        {
            // this fires but NewPageIRPRO is null
            if (PageBreak != null)
            {
                PageBreak("dummylink");
            }
        }
    }
