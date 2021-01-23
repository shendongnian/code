    string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\db1.accdb";
    
    using (OleDbConnection conn = new OleDbConnection(connectionString))
    {
    	string query = "SELECT [Username], [Password], [UserType] FROM [Member] WHERE [Username] = @Username";
    
    	conn.Open();
    
    	using (OleDbCommand cmd = new OleDbCommand(query, conn))
    	{
    		cmd.Parameters.Add("@Username", System.Data.OleDb.OleDbType.VarChar);
    		cmd.Parameters["@Username"].Value = this.textBox1.Text;
    
    		using (OleDbDataReader dReader = cmd.ExecuteReader())
    		{
    			bool isValidPassword = false;
    			if (dReader.Read())
    			{
    				string password = (string)dReader["Password"];
    				bool isValidPassword = BCrypt.CheckPassword(this.textBox2.Text, password);
    				if (isValidPassword)
    				{
    					UserInformation.CurrentLoggedInUser = (string)dReader["Username"];
    					UserInformation.CurrentLoggedInUserType = (string)dReader["UserType"];
    					this.Hide();
    					this.Close();
    				}
    			}
    			if (!isValidPassword)
    			{
    				Validation(sender, e);
    
    				RecursiveClearTextBoxes(this.Controls);
    			}
    		}
    	}
    }
