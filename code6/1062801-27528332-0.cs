        public class YourContext : DbContext
        {
            //...
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Entity<JobOffer>().
                    HasMany(c => c.Languages).
                    WithMany(p => p.JobOffers).
                    Map(
                        m =>
                        {
                            m.MapLeftKey("JobOfferId");
                            m.MapRightKey("LanguageId");
                            m.ToTable("JobOfferLanguages");
                        });
        
            }
            //...
        }
