    public partial class User : IdentityUser {
            public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager) {
                var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
                // Add custom user claims here
                return userIdentity;
            }
            /// <summary>
            /// The Date the User Registered for general information purposes
            /// </summary>
            public DateTime DateRegistered { get; set; }
        }
