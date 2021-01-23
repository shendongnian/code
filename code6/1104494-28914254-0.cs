    using System;
    using System.Data.SqlClient;
    
    class Program
    {
        static void Main()
        {
    	string connectionString = ConsoleApplication1.Properties.Settings.Default.ConnectionString;
    	using (SqlConnection con = new SqlConnection(connectionString))
    	{
    	    con.Open();
            string cmd = "(SELECT * FROM tblEmployee WHERE Username = 'Venz')";
    	    using (SqlCommand command = new SqlCommand(cmd, con))
    	    using (SqlDataReader reader = command.ExecuteReader())
    	    {
    		while (reader.Read())
    		{
    		    Console.WriteLine( reader["Username"].ToString());
    		}
    	    }
    	}
        }
    }
