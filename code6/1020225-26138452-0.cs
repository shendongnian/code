    public partial class MyWindow : Window
    {
        private readonly ObservableCollection<string> _list_match = new ObservableCollection<string>();
        public ObservableCollection<string> list_match { get { return _list_match; } }
        
        public MyWindow()
        {
            InitializeComponent();
            this.DataContext = this;
        }
    }
