    public class UserProfile
    {
        public UserProfile()
        {
            this.Casefiles = new HashSet<Casefile>();
        }
        [Display(Name="Author")]
        public string FullName
        {
            get { return LastName + ", " + FirstName; }
        }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int UserProfileId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        [EmailAddress]
        public string EmailAddress { get; set; }
        // UserInRole Level
        public string Role { get; set; }
        [Display(Name = "Request Account Uplevel to Contributor")]
        public bool RequestUplevel { get; set; }
        public virtual ICollection<Casefile> Casefiles { get; set; }
    }
