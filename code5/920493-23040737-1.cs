    //The following example shows how Test window can reference an existing instance of    
    //Main window. All you need to do is instantiate it using the example code in my notes below.
    public partial class Test : Window
    {
        MainWindow main = null;
        public Test(MainWindow existingMainWindow)
        {
            main = existingMainWindow;
            InitializeComponent();
        }
        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //main.ShowDialog(); 
            String nao_ip = main.nao_ip;
            MessageBox.Show(nao_ip);
        }
    }
