    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows;
    
    namespace WpfApplication7
    {
        /// <summary>
        ///     Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                Loaded += MainWindow_Loaded;
            }
    
            private void MainWindow_Loaded(object sender, RoutedEventArgs e)
            {
                var collection = new MyItemCollection();
                collection.Add(new MyItem {Name = "item1", IsChecked = true});
                collection.Add(new MyItem {Name = "item2", IsChecked = false});
    
                CheckBox1.DataContext = collection;
            }
        }
    
        internal class MyItem : INotifyPropertyChanged
        {
            private bool _isChecked;
            private string _name;
    
            public string Name
            {
                get { return _name; }
                set
                {
                    _name = value;
                    OnPropertyChanged();
                }
            }
    
            public bool IsChecked
            {
                get { return _isChecked; }
                set
                {
                    _isChecked = value;
                    OnPropertyChanged();
                }
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    
        internal class MyItemCollection : ObservableCollection<MyItem>
        {
        }
    }
