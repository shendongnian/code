    public partial class MainWindow : Window
    {
        private MyMainViewModel VM {get;set;}
        public MainWindow()
        {
            InitializeComponent();
            VM = new MyMainViewModel()
            this.Content = VM;
        }
        private void Btnsend_Click(object sender, RoutedEventArgs e)
        {
            VM.NextImage();
        }
    }
