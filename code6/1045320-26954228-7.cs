         public ExampleDataFiller (BloodBankContext bloodBankContext)
            {
                this.bloodBankContext = bloodBankContext;
    
                // Only initialize the data if none is there
                if(!bloodBankContext.BloodDonors.Any())
                {
                     ExampleDonators=new List<BloodDonor>();
        
                     var bloodDonor1 = new BloodDonor()
                     {
                         FirstName="Marcus",
                         LastName="Wilkins",
                         DateofBirth=new DateTime(1960, 10, 27),
                         DateOfRegistration=DateTime.Now,
                         BloodType=BloodTypes.ABRHminus,
                     };
                     //.
                     //.
                     //.
                     // etc
                }
            }
 
