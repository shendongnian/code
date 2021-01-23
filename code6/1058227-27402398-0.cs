    // web.config   
    <add name="MyDataConnection" 
		 connectionString="data source=server_name; database=myDB; user id=my.user.iDB password=PASSW0rd" 		 
         providerName="System.Data.SqlClient" 
	/>
    // SearchController.cs
    string CS = ConfigurationManager.ConnectionStrings["MyDataConnection"].ConnectionString;
    using (SqlConnection connection = new SqlConnection(CS))
		{
			SqlCommand command = new SqlCommand("SELECT * FROM Search", connection);
			connection.Open();
			SqlDataReader rdr = command.ExecuteReader();
		}
