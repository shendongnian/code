	int searchId = 4;
	string connectionString = @"Data Source=.\SQLEXPRESS;AttachDbFilename=D:\lagenius\JIvandhara ngo\JIvandhara ngo\ngo.mdf;Integrated Security=True;User Instance=True"
	using (SqlConnection connection = new SqlConnection(connectionString)) {
	    connection.Open();
	    using (SqlCommand command = new SqlCommand(
	    	"select  receipt_no, name, rupees, pay_by, date " +
            "from receipt_info where receipt_no = @Id", connection))
	    {
            command.Parameters.Add(new SqlParameter("Id", searchId));
    		SqlDataReader reader = command.ExecuteReader();
	    	while (reader.Read())
    		{
    		}
	    }
	}
