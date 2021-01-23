    public static string ModelConnStr()
    {
	System.Data.SqlClient.SqlConnectionStringBuilder sqlcon = new System.Data.SqlClient.SqlConnectionStringBuilder();
	sqlcon.DataSource = "your datasource";
	sqlcon.InitialCatalog = "your db";
	sqlcon.UserID = "id";
	sqlcon.Password = "pswrd";
	System.Data.EntityClient.EntityConnectionStringBuilder mdlcon = new System.Data.EntityClient.EntityConnectionStringBuilder();
	mdlcon.Metadata = "res://*/BMModel.csdl|res://*/BMModel.ssdl|res://*/BMModel.msl";
	mdlcon.Provider = "System.Data.SqlClient";
	mdlcon.ProviderConnectionString = sqlcon.ConnectionString;
	return mdlcon.ConnectionString;
    }
