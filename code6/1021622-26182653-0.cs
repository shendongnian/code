    public partial class Upload : Window {
        public Upload(YourMainWindowClassName main){
            InitializeComponent();
            DataContext = main.LoggedUsers; // or whatever your property name is
        }
    }
