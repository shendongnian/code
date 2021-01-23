    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            // dummy data source / Your ObservableCollection
            var yourObservableCollection = Enumerable.Range(0, 30)
                .Select(i => new MyType { FirstValue = i, SecondValue = i.ToString() });
            // Create CollectionView based on the data you want to show
            MySource = CollectionViewSource.GetDefaultView(yourObservableCollection);
            InitializeComponent();
        }
        public ICollectionView MySource { get; set; }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            foreach (var item in MySource.OfType<MyType>())
            {
                Console.WriteLine("MyType - First: {0}, Second: {1}",
                    item.FirstValue,
                    item.SecondValue);
            }
        }
    }
    public class MyType
    {
        public int FirstValue { get; set; }
        public string SecondValue { get; set; }
    }
