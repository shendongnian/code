    public partial class Viewlist : Window
    {
        public Visitor VisitorDataContext { get; set; }    
        public Viewlist(Visitor visitor)
        {
            InitializeComponent();
            this.DataContext = this;
            VisitorDataContext = visitor;
        }
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
