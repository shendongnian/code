    public class DealsUser : IDealsUser
    {
        public DealsUser() : this("GUEST")
        {
        }
    
        public DealsUser(string username)
        {
            this.Username = username;
            this.IsAdministrator = false;
            this.IsPlanModerator = false;
            this.IsPlanner = false;
        }
    
        public string Username { get; set; }
    
        public bool IsAdministrator { get; set; }
    
        public bool IsPlanModerator { get; set; }
        public bool IsPlanner { get; set; }
    
        private string _emailAddress;
        public string EmailAddress
        {
            get
            {
                return _emailAddress ?? string.Format(
                    "{0}@mycompany.co.za", this.Username);
            }
            set
            {
                _emailAddress = value;
            }
        }
    
        public override string ToString()
        {
            return this.Username;
        }
