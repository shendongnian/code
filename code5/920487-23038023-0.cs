    /// <summary>
    /// Interaction logic for Test.xaml
    /// Note: The main.ShowDialog() method displays the main window modally.
    /// </summary>
    public partial class Test : Window
    {
        MainWindow main = new MainWindow();
        public Test()
        {
            InitializeComponent();
        }
        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            main.ShowDialog(); 
            String nao_ip = main.nao_ip;
            MessageBox.Show(nao_ip);
        }
    }
