    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            DataContext = Enumerable.Range(1,10)
                                    .Select(x => new ComputerInfo()
                                    {
                                        Name = "Computer" + x.ToString(),
                                        Ip = "192.168.1." + x.ToString()
                                    });
            
        }
        public ComputerInfo SelectedComputer { get; set; }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(SelectedComputer.Ip);
        }
    }
