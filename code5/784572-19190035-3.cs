    using System.Collections.ObjectModel;
    using System.Windows;
    
    namespace WpfApplication10
    {
        /// <summary>
        ///     Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            private readonly ObservableCollection<string> _collection = new ObservableCollection<string>();
    
            public MainWindow()
            {
                InitializeComponent();
            }
    
            public ObservableCollection<string> Collection
            {
                get { return _collection; }
            }
    
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                _collection.Clear();
                for (int i = 0; i < 5; i++)
                {
                    _collection.Add("method 1 item " + i);
                }
            }
    
            private void Button_Click_1(object sender, RoutedEventArgs e)
            {  _collection.Clear();
                for (int i = 0; i < 5; i++)
                {
                    _collection.Add("method 2 item " + i);
                }
            }
        }
    }
