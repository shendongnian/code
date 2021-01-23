    public void InsertMethod(){
		SqlConnection sqlConn = null;
		SqlCommand sqlCmd = null;
		try
		{
			String sqlConnectionString = "your database connection string";
			//create an sql connection, providing sql connection string
			sqlConn = new SqlConnection(sqlConnectionString);
			//open the connection
			sqlConn.Open();  
			//insert statement with column names and parameters(@Name, @Email etc, the way how we can pass arguments for insert statement)
			String sqlCommandString =   "INSERT INTO Contact (Name, Email_Address, Company, Contact_Number, Subject, Message) " +
										"VALUES(@Name, @Email_Address, @Company, @Contact_Number, @Subject, @Message);";
			// Create the command object using sql connection string & sql connection
			sqlCmd = new SqlCommand(sqlCommandString, sqlConn);
			//add values to the provided parameters
			sqlCmd.Parameters.AddWithValue("@Name", TextBox1.Text);
			sqlCmd.Parameters.AddWithValue("@Email_Address", TextBox2.Text);
			sqlCmd.Parameters.AddWithValue("@Company", TextBox3.Text);
			sqlCmd.Parameters.AddWithValue("@Contact_Number", TextBox4.Text);
			sqlCmd.Parameters.AddWithValue("@Subject", TextBox5.Text);
			sqlCmd.Parameters.AddWithValue("@Message", TextBox6.Text);
			//execute the SQL command(rowsAdded will give the number of rows added to the database)
			int rowsAdded = sqlCmd.ExecuteNonQuery();
		}catch (Exception ex)
		{
			throw (ex);
		}
		finally
		{
			//closing the sql conncetion
			sqlConn.Close();
			//disposing
			sqlCmd.Dispose();
			sqlConn.Dispose();
		}}`
