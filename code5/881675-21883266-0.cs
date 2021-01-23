    public class Profile
    {
       public Guid ProfileId { get; set; }
       public virtual ICollection<Account> Accounts { get; set; }
       // other properties
    }
    Public class Account
    {
        public Guid AccountId { get; set; }
        public virtual ICollection<Profile> Profiles { get; set; }
        // other properties
    }
