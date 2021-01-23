    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
    
            DataContext = new Person[] {
                new Person() { Name = "Paul Leary", Email="paul@contoso.com" },
                new Person() { Name = "Andy Dale", Email="andy@contoso.com" },
                new Person() { Name = "Mike 'The Firestarter' Douglas", Email = "an_incredibly_long_email_address@contoso.com" }
            };
    
        }
    }
