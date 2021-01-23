    public class Log
    {
        public virtual User User { get; set; }
        //Add this property
        public virtual string UserProfileId { get; set; }
        public string UserProfileName
        {
            get { return User != null ? User.Name : UserProfileId; }
        }
    }
