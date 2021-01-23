    namespace Bug
    {
        public partial class MainPage : PhoneApplicationPage
        {
            // Constructor
            public MainPage()
            {
                InitializeComponent();
                Items = new ObservableCollection<string>();
                Items.CollectionChanged += Items_CollectionChanged;
            }
            void Items_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
            {
                Debug.WriteLine("CollectionChanged");
            }
            public ObservableCollection<string> Items { get; private set; }
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                Items.Add("A");
                // This works as expected
                //Items.Add(Guid.NewGuid().ToString());
            }
            private void Button_Click1(object sender, RoutedEventArgs e)
            {
                Items.Add("B");
                // This works as expected
                //Items.Add(Guid.NewGuid().ToString());
            }
            private void Button_Click2(object sender, RoutedEventArgs e)
            {
                Items.Clear();
            }
        }
    }
