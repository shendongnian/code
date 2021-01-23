	public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var context = new SomeContext();
            DataContext = context;
            context.AddPerson();
        }
    }
