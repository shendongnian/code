    public partial class Login : Page
    {
        public Login(IHomeVisibility homeBtnVisiblity)
        {
            InitializeComponent();
            homeBtnVisiblity.HomeVisibility = Visibility.Visible;
        }
    }
