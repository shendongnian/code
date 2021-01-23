    SqlConnection con1 = new SqlConnection("your connection string");
    DataTable dt = new DataTable();
    con1.Open();
    SqlDataReader myReader = null;  
    SqlCommand myCommand = new SqlCommand("your query", con1);
    
    myReader = myCommand.ExecuteReader();
    
    while (myReader.Read())
    {
    	txtName.Text = (myReader["name"].ToString());
    	txtEmail.Text = (myReader["email"].ToString());
    	//and whatever you have to retrieve
    }
    con1.Close();
