    public class AccountMembershipProvider : MembershipProvider
    {
        private readonly IUsers _users;
        public AccountMembershipProvider()
        {
            _users = ServiceLocator.Current.GetInstance<IUsers>();
        }
        
        public override bool ValidateUser(string username, string password)
        {
            return _users.IsValidLogin(username, password);
        }
    ...
    }
