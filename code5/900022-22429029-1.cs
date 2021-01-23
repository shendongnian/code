    using (SqlCommand cmd1 = GetCommand(connection, transaction, 
                                                      "select @@IDENTITY", null))
    {
    	try
    	{
    		object value = cmd1.ExecuteScalar();
    		studentId = Convert.ToInt32(value);
    	}
    	catch (Exception ex)
    	{
    		transaction.Rollback();
    		MessageBox.Show(ex.Message.ToString());
    	}
    } 
