    public class UserRegisterViewModel
    {
        private User _user;
        public User User
        {
            get { return _user = (_user ?? new User()); }
        }
        public string Password
        {
            get { return User.Password; }
            set { User.Password = value; }
        }
        [DataType(DataType.Password)]
        [System.Web.Mvc.Compare("Password", ErrorMessage = "Passwords must match")]
        [Required(ErrorMessage = "Confirm password is required")]
        [DisplayName("Confirm Password")]
        public string CPassword { get; set; }
    }
