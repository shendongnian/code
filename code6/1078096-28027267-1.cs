    using (var service = new OrganizationService(connection))
    using (var context = new OrganizationServiceContext(service))
    {
	    var contactRecord = new Entity("contact");
	    contactRecord.Attributes.Add("firstname", "Peter");
	    contactRecord.Attributes.Add("lastname", "Jackson");
	    context.AddObject(entity);
	    context.SaveChanges();
    }
    
