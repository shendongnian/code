    public class LoginViewModel
    {
        public string Username{get;set;}
        public string Password{get;set;}
        public int UserTypeId{get;set;}
        public IEnumerable<UserTypes> UserTypes{get;set;}
    }
