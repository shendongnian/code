    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
            DataContext = PersonService.ReadFile(@"c:\file.csv");
        }
    }
