MainWindow
    public partial class MainWindow : Window
    {
        public ObservableCollection<long> WindowCollection { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            WindowCollection = new ObservableCollection<long>();
            WindowCollection.CollectionChanged += new NotifyCollectionChangedEventHandler(WindowCollection_CollectionChanged);
        }
        private void WindowCollection_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                System.Diagnostics.Debug.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> WindowCollection_CollectionChanged called");
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WindowCollection.Add(1);
            WindowCollection.Add(2);
        }
    }
