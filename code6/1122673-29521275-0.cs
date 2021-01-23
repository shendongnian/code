    public class User: IdentityUser
    {
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }
    
        [Required]
        [StringLength(100)]
        public string LastName { get; set; }
    
        public DateTime JoinedOn { get; set; }
        public virtual Student Student { get; set; }
    
        public virtual Teacher Teacher { get; set; }
    
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(
            UserManager<User, Guid> manager)
        {
            // Note the authenticationType must match the one defined in
            // CookieAuthenticationOptions.AuthenticationType 
            var userIdentity = await manager.CreateIdentityAsync(
                this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here 
            return userIdentity;
        } 
    }
