    public class UserViewModel 
    {
        public User User;
        public string UserEmail { get { return User.Email; } }
    
        [DataType(DataType.EmailAddress)]
        [Compare("UserEmail")]
        public string ConfirmEmail { get; set; }
    }
