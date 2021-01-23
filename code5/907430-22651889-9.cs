MainWindow
    public partial class MainWindow : Window
    {
        public ObservableCollection<long> WindowCollection { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            WindowCollection = new ObservableCollection<long>();
            WindowCollection.Add(1);
            WindowCollection.Add(2);            
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WindowCollection.Add(3);
            WindowCollection.Add(4);
        }
    }
UserControl
    public partial class UserControl1 : UserControl
    {
        #region Public Section
        public ObservableCollection<long> UCItems { get; set; }
        public static UserControl1 control;
        #endregion
        public UserControl1()
        {
            InitializeComponent();
            UCItems = new ObservableCollection<long>();            
        }
        #region UCItemsSource Property
        public static readonly DependencyProperty UCItemsSourceProperty = DependencyProperty.Register("UCItemsSource", 
                                                                                                      typeof(IEnumerable), 
                                                                                                      typeof(UserControl1),
                                                                                                      new PropertyMetadata(null, new PropertyChangedCallback(OnUCItemsSourceChanged)));
        public IEnumerable UCItemsSource
        {
            get { return (IEnumerable)GetValue(UCItemsSourceProperty); }
            set { SetValue(UCItemsSourceProperty, value); }
        }
        #endregion
        private static void OnUCItemsSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            control = d as UserControl1;
            var items = e.NewValue as ObservableCollection<long>;
            items.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChanged);
            AddItem(control, items);
        }
        private static void CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            var items = sender as ObservableCollection<long>;
            control.UCItems.Clear();
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                AddItem(control, items);
            }
        }
        private static void AddItem(UserControl1 userControl, ObservableCollection<long> collection) 
        {
            if (collection.Count > 0)
            {
                foreach (var item in collection)
                {
                    userControl.UCItems.Add(item);
                }
            }
        }
    }
