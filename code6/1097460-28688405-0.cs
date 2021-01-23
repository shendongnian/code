      SqlConnection con = new SqlConnection(MyConnectionString);
    SqlCommand objCmd;
    con.Open();
    SqlDataReader dtReader;
    String strSQL;
    strSQL = "SELECT * FROM " + DropDownList1.SelectedValue ;
    
    objCmd = new SqlCommand(strSQL, con);
    dtReader = objCmd.ExecuteReader();
    
    GridView3.DataSource = dtReader;
    GridView3.DataSourceID = String.Empty;
    GridView3.DataBind(); 
    
    dtReader.Close();
    dtReader = null; 
