    public partial class MainWindow : Window
    {
        public ViewModel ViewModel;
        public MainWindow()
        {
            ViewModel = new ViewModel();
            ViewModel.Persons.Add(new Person
            {
                Age = 29,
                Name = "Mustermann"
            });
            ViewModel.Persons.Add(new Person
            {
                Age = 35,
                Name = "Meyer"
            });
            this.DataContext = ViewModel;
            InitializeComponent();
        }
