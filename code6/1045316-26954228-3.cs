     public class BloodBankContext : DbContext
        {
            public BloodBankContext()
                : base("BloodBankDatabase1")
            {
                Database.SetInitializer<BloodBankContext>(new BloodBankContextInitializer<BloodBankContext>());
            }
            public DbSet<BloodDonor> BloodDonors { get; set; }
            public DbSet<BloodDonation> BloodDonations { get; set; }
            public DbSet<StoredBlood> storedBlood { get; set; }
        }
