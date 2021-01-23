    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> strings;
        public MainWindow()
        {
            InitializeComponent();
            strings = new List<string>();
            strings.Add("this");
            strings.Add("that");
            listbox1.DataContext = strings;
       
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            passto pt = new passto(strings);
            if (!pt.ShowDialog() ?? false)
            {
                MessageBox.Show("woohooo");
            }
        }
    }
