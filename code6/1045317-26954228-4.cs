    public class BloodBankContext : DbContext
            {
                public BloodBankContext()
                    : base("BloodBankDatabase1")
                {
                    Database.SetInitializer<BloodBankContext>(null); // this means that keep the database data as it is and don't change it.
                }
                public DbSet<BloodDonor> BloodDonors { get; set; }
                public DbSet<BloodDonation> BloodDonations { get; set; }
                public DbSet<StoredBlood> storedBlood { get; set; }
            }
