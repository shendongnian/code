    public class ApplicationUser : IdentityUser
        {
            public UserType UserType { get; set; }
            
            [JsonIgnore]
            public override string PasswordHash
            {
                get { return base.PasswordHash; }
                set { base.PasswordHash = value; }
            }
        }
