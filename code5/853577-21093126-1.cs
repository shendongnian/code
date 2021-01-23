    using System.Collections.ObjectModel;
    using System.Windows;
    
    namespace WpfApplication1
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
    
        {
            public  ObservableCollection<string>  observableCollection  =  new ObservableCollection<string>();
            public MainWindow()
            {
                for (int i = 0; i < 10; i++)
                {
                    observableCollection.Add( "item:"+ i.ToString());
                }
                InitializeComponent();
                comboBox1.ItemsSource = observableCollection;  
            }
    
            private void Window_Loaded(object sender, RoutedEventArgs e)
            {
    
            }
        }
    }
