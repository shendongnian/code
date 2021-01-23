    COMAdminCatalog catalog = new COMAdminCatalog();
    COMAdminCatalogCollection applications = catalog.GetCollection("Applications");
    
    applications.Populate();
    
    for (int i = 0; i < applications.Count; i++)
    {
    	COMAdminCatalogObject application = COMAppCollectionInUse.Item[i];
    	if (application.Name == "Your COM+ application name")
    	{
                application.Value["Identity"] = "nt authority\\localservice"; // for example
    	}
    }
