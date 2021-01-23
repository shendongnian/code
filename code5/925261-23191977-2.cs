    bool CheckDuplicateCustomer(int custid)
    {
    	SqlConnection con = new SqlConnection();
    	con.ConnectionString = @"Data Source=HP\SQLEXPRESS100;Database=CD_Gallery;Integrated Security=true";
    	con.Open();
    	if (con.State == System.Data.ConnectionState.Open)
    	{
    	SqlCommand cmd = new SqlCommand("select count(*) from Customer_Info where custid = @custid", con);
    	cmd.Connection = con;
    	cmd.CommandType = System.Data.CommandType.Text;
    	cmd.Parameters.AddWithValue("@custid",custid);
    	int CustomerCount = Convert.ToInt32(cmd.ExecuteScalar());
    	}
    	con.Close();
    	if(CustomerCount > 0)
    		return true;
    	return false;
    }
