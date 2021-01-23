    SqlConnection connection = new SqlConnection("......");
    
    SqlCommand command = new SqlCommand();
    command.Connection = connection;
    command.CommandType = CommandType.StoredProcedure;
    command.CommandText = "<<<Enter your stored Procedure Name>>>";
    
    // create sql parameter if your procedure expects any input
    SqlParameter param1 = new SqlParameter("@spParam1",SqlDbType.NVarChar);
    
    // add parameters to parameters collection
    command.Parameters.Add(param1);
    
    // you can define more parameters based on your Stored Procedure's design
    
    // set this parameter to a value we would like to set
    command.Parameters["@spParam1"].Value = "<<Input goes here...>>"; 
    
    // open connection
    command.Connection.Open();
    
    // populate data reader with return data result set 
    // and close connection after populating data set
    SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
    
    // assign data source to Chart
    chart1.DataSource = reader;
    
    // Set series data source to stored procedures returned data set's columns
    chart1.Series[0].ValueMemberX = "ProductName";
    chart1.Series[0].ValueMembersY = "TotalPurchase";
    
    // data bind chart
    chart1.DataBind(); 
