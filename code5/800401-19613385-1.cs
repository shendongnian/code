    private static void SeedContactsAndAddress(StoreContext context)
    {
        // Each Address, which I believe is a collection in this case, but there is only
        // one, will have to be created and added to each contact.
    
    	var addressesForDarthVader = new List<Address>
    	{
    		new Address { HomeAddress = "1300 DeathStar", BusinessAddress = "444 Imperial Fleet", PoBox = "PO Box 1335" }
    		// Add more addresses for Darth Vader if you need to
    	};
    
    	// Rinse and repeat for the other contacts;
    
    	context.Contacts.AddOrUpdate(l => l.LastName,
    		new Contact() { FullName = "Darth Vader", FirstName = "Darth", LastName = "Vader", Addresses = addressesForDarthVader },
    		new Contact() { FullName = "Luke Skywalker", FirstName = "Luke", LastName = "Skywalker", },
    		new Contact() { FullName = "Tony Stark", FirstName = "Tony", LastName = "Stark", },
    		new Contact() { FullName = "Ricky Bobby", FirstName = "Ricky", LastName = "Bobby", },
    		new Contact() { FullName = "Trix Rabbit", FirstName = "Trix", LastName = "Rabbit", });
    
    	context.SaveChanges();
    }
