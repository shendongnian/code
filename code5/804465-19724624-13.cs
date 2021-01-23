    public partial class MainWindow : Window
    {
        public List<string> Links
        {
            get { return (List<string>)GetValue(LinksProperty); }
            set { SetValue(LinksProperty, value); }
        }
    
        // Using a DependencyProperty as the backing store for Links.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LinksProperty =
            DependencyProperty.Register("Links", typeof(List<string>), typeof(MainWindow), new PropertyMetadata(0));
    
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }
    
        private List<string> GetLinks()
        {
            var links = new List<string>();
            HtmlDocument doc = new HtmlDocument();
            doc.Load("YourHtmlFileInHere");
            foreach (HtmlNode link in doc.DocumentNode.SelectNodes("//a[@href]"))
            {
                HtmlAttribute attribute = link.Attributes["href"];
                if (attribute != null)
                {
                    links.Add(attribute.Value);
                }
            }
            return links;
        }
    
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Links = this.GetLinks();
        }
    }
