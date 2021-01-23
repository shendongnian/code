    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows;
    using WpfApplication10.Annotations;
    
    namespace WpfApplication10
    {
        /// <summary>
        ///     Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window, INotifyPropertyChanged
        {
            private ObservableCollection<string> _collection = new ObservableCollection<string>();
    
            public MainWindow()
            {
                InitializeComponent();
            }
    
            public ObservableCollection<string> Collection
            {
                get { return _collection; }
                set
                {
                    if (Equals(value, _collection)) return;
                    _collection = value;
                    OnPropertyChanged();
                }
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                Collection = new ObservableCollection<string>(new[] {"1", "2"});
            }
    
            private void Button_Click_1(object sender, RoutedEventArgs e)
            {
                Collection = new ObservableCollection<string>(new[] {"3", "4"});
            }
    
            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
