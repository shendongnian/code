	// assuming you have created a DBML file and added your tblCollateral_Codes table
	var connectionString = System.Configuration.ConfigurationManager.AppSettings("linq2sqlConnectionString");
	using (var db = new CollateralDatabase(connectionString))
	{
		// result is a list of strings, holding in this case 'Comml Bldg - Fam5+/Apt' and so on...
		var result = db.Table
						.Select(tblCollateral_Codes_Entity => tblCollateral_Codes_Entity.Collateral_Code_Desc)
						.ToList();
	}
