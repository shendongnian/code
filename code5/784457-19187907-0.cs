    public partial class MainWindow : Window
    {
        NewWindow optionsWindow = new NewWindow();
    
        public MainWindow()
        {
            InitializeComponent();
                
            optionsWindow.button1.Click += new RoutedEventHandler(button1_Click);
            optionsWindow.Show();
                
        }
    
        void button1_Click(object sender, RoutedEventArgs e)
        {
            double d = Convert.ToDouble(optionsWindow.textBox1.GetLineText(0));
        }
    
            
    }
