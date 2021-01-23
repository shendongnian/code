        public class UserForm : Window
        {
            public Users userObject { get; set; }
        
            public UserForm(Users user)
            {
                InitializeComponent();
                this.DataContext = user;
            }
        }
