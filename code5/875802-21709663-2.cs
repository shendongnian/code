    using System.Data.SqlClient;
    string queryString = "SELECT tPatCulIntPatIDPk, tPatSFirstname, tPatSName, tPatDBirthday  FROM  [dbo].[TPatientRaw] WHERE tPatSName = @tPatSName";
    string connectionString = "Server=.\\PDATA_SQLEXPRESS;Database=;User Id=sa;Password=2BeChanged!;";
    
    using (SqlConnection connection = new SqlConnection(connectionString))
    {
    	SqlCommand command = new SqlCommand(queryString, connection);
    	command.Parameters.AddWithValue("@tPatSName", "Your-Parm-Value");
    	connection.Open();
        SqlDataReader reader = command.ExecuteReader();
        try
        {
    		while (reader.Read())
            {
    			Console.WriteLine(String.Format("{0}, {1}",
    			reader["tPatCulIntPatIDPk"], reader["tPatSFirstname"]));// etc
            }
    	}
        finally
        {
    		// Always call Close when done reading.
            reader.Close();
    	}
    }
