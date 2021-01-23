    /// <summary>
    /// Interaction logic for passto.xaml
    /// </summary>
    public partial class passto : Window
    {
        public passto(List<string> plist)
        {
            InitializeComponent();
            passlist.DataContext = plist;
        }
    }
