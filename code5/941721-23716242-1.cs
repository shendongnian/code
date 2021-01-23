    namespace WpfApplication1
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            MainViewModel vm = new MainViewModel();
            public MainWindow()
            {
                InitializeComponent();
                this.DataContext = vm;
            }
    
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                vm.MyLabel += 1;
            }
        }
    }
