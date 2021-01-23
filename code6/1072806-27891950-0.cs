    public class UserProfile : IdentityUser
    {
        [ForeignKey("ProfileInfo")]
        public int ProfileInfoId Profile { get; set; }
        public ProfileInfo ProfileInfo { get;set; }
    }
