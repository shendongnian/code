	using (ImpersonatedUser user = new ImpersonatedUser("USER_NAME", "DOMAIN_NAME", "USER PASSWORD"))
	{
		COMAdmin.COMAdminCatalog objCatalog = new COMAdmin.COMAdminCatalog();
		objCatalog.Connect("SERVER_NAME");
		COMAdmin.COMAdminCatalogCollection objAppCollection =
			(COMAdmin.COMAdminCatalogCollection) objCatalog.GetCollection("Applications");
		objAppCollection.Populate();
	}
