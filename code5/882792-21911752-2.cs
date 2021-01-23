        public class ApplicationUser 
            {
                public ApplicationUser()
                {
                    // Settings = new UserSettings();
                }
                    [Key]
                public string Id { get; set; }
                public string EmailAddress { get; set; }
            
                public virtual UserSettings Settings { get; set; }
            }
            
            public class UserSettings
            {
                [Key]
                public string ApplicationUserId { get; set; }
            
                public virtual ApplicationUser ApplicationUser { get; set; }
            }
            
         public class Context : DbContext
                { 
                  protected override void OnModelCreating(DbModelBuilder modelBuilder)
                    {
                        base.OnModelCreating(modelBuilder);
            
                        modelBuilder.Entity<UserSettings>()
                                         .HasRequired(t => t.ApplicationUser)
                                         .WithRequiredPrincipal(t => t.Settings);
            
                    }
            }
