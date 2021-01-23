    public class BloodBankContextInitializer : DropCreateDatabaseAlways<BloodBankContext>
    {
        protected override void Seed(BloodBankContext context)
        {
            // Make sure that your database has no 
            if (!context.BloodDonors.Any())
            {
                // Seed your database by the data that you want. 
                var  bloodDonor1 = new BloodDonor()
                {
                    FirstName = "Marcus",
                    LastName = "Wilkins",
                    DateofBirth = new DateTime(1960, 10, 27),
                    DateOfRegistration = DateTime.Now,
                    BloodType = BloodTypes.ABRHminus,
                };
    
                context.BloodDonors.Add(bloodDonor1);
                //.
                //.
                //.
                //. etc
    
                context.SaveChanges();
            }
        }
    }
