    // Get the number of items in the Contacts folder. To keep the response smaller, request only the TotalCount property.
    ContactsFolder contactsfolder = ContactsFolder.Bind(service,
                                                        WellKnownFolderName.Contacts,
                                                        new PropertySet(BasePropertySet.IdOnly, FolderSchema.TotalCount));
    
    // Set the number of items to the smaller of the number of items in the Contacts folder or 1000.
    int numItems = contactsfolder.TotalCount < 1000 ? contactsfolder.TotalCount : 1000;
    
    // Instantiate the item view with the number of items to retrieve from the Contacts folder.
    ItemView view = new ItemView(numItems);
    
    view.PropertySet = new PropertySet(ContactSchema.CompanyName, ContactSchema.EmailAddress1);
    
    // Retrieve the items in the Contacts folder that have the properties you've selected.
    FindItemsResults<Item> contactItems = service.FindItems(WellKnownFolderName.Contacts, view);
	
	foreach(var contact in contactItems)
	{
		
                Contact contact    = item as Contact;
                // Filter / Group by company name
                // contact.Companyname
	}
