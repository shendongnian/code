	//Set the connection string to the Kentico Database in the web.config to a variable called CMSConnectionString
	string CMSConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["CMSConnectionString"].ConnectionString;
	//Sets the text of the query we want to execute on the database to a variable called queryText
	string queryText = "SELECT * FROM dbo.CMS_Countries";
	//Creates a new instance of the SqlDataAdapter object and calls it "adapter".  
	//We pass in the text of the query we want to executre on the Kentico database, and the connetion string to the Kentico database.
	SqlDataAdapter adapter = new SqlDataAdapter(queryText, CMSConnectionString);
	//Creates a new instance of the DataSet object and calls it "countries".
	DataSet countries = new DataSet();
	//Fills the "countries" dataset with the data retrieved by our query on the Kentico database.
	adapter.Fill(countries);
	//Sets the datasource of the repeater to the dataset that we just created.
	repeater.DataSource = countries;
	//Binds the datasource to the repeater server control
	repeater.DataBind();
