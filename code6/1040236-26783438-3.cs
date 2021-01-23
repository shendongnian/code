          public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            MyList=new ObservableCollection<ListViewModel>();
        }
        private ObservableCollection<ListViewModel> myList;
        public ObservableCollection<ListViewModel> MyList
        {
            get { return myList; }
            set { myList = value; }
        }
        private void Button_OnClick(object sender, RoutedEventArgs e)
        {
            MyList.Add(new ListViewModel("MyValue"));
        }
    }
