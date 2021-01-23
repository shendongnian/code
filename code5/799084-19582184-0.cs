     <add name="sConnectionString"
      connectionString="Integrated Security=SSPI;Persist Security Info=False;User ID=userid;Initial Catalog=databasename;Data Source=.\SQLEXPRESS"
      providerName="System.Data.SqlClient" />
	  
	  SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["sConnectionString"].ConnectionString);
