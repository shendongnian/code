    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var logic  = new LogicObject();
            DataContext = logic.Collection;
        }
    }
