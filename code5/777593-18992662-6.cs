    namespace WpfStackoverflow
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                Parent p = new Parent();
                p.Mine = new Mine();
                p.Mine.Name = "Hello world";
                this.DataContext = p;
            }
        }
    }
