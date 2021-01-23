    public class UserDetail : User
    {
        public UserDetail(User x)
        {
            this.Id = x.Id;
            this.Name = x.Name;
            this.EMail = x.EMail;
        }
        public bool IsOnline { get; set; }
    }
