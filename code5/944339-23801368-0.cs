    public class ArchiveData
    {
        public Credentials credentials {get; private set;}
    
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
    
        public ArchiveData(Credentials credentials)        
        {            
            this.credentials = credentials;
        }
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
