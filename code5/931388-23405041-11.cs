    public class RegisterViewModel
    {
        public UserAccount UserAccount { get; set; }
        public RegisterViewModel()
        {
            UserAccount = new UserAccount();
        }
        [AttributesFrom(typeof(MyApp.DataModel.UserAccount), "UserName")]
        string UserName { get; set; }
        [AttributesFrom(typeof(MyApp.DataModel.UserAccount), "Password")]
        string Password { get; set; }
        [AttributesFrom(typeof(MyApp.DataModel.UserAccount), "Password")]
        [Display(Name = "Confirm Password", Prompt = "Confirm Password"), Compare("Password", ErrorMessage = "Your confirmation doesn't match.")]
        public string PasswordConfirmation { get; set; }
    }
