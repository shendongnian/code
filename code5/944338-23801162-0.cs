    public class ArchiveData : Credentials
    {
        public string userData
        {
            get
            {
                return this.userData;
            }
            set
            {
                this.userData = value;
            }
        }        
        //other properties here
        public ArchiveData(string userId, string password) : base(userId, password) {}
    }
    public class Credentials
    {
        public string userId { get; set; }
        public string password { get; set; }
        public Credentials(string userId, string password)
        {
            this.userId = userId;
            this.password = password;
        }
    }
