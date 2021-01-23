    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();
            var mv = new MainViewModel
            {
                Models = { new SomeModel { BoolField = true, TextField = "One" }, new SomeModel { TextField = "Two" } },
            };
            DataContext = mv;
        }
    }
