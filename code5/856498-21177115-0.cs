         string strSQLSelect = "SELECT CUsername FROM myCustomer WHERE CuserName=@CuserName ";
            cmd = new OleDbCommand(strSQLSelect, mDB);
            cmd.Parameters.Add("@CuserName", [YourLoginID]);
            rdr = cmd.ExecuteReader();
    
     while (rdr.Read() == true) 
            {
                if (rdr["CUsername"].ToString() == "admin")
                {
                    DetailsView1.Visible = true;
    	        //Initial Session
    	        Session["CUsername"]=rdr["CUsername"].ToString();
                }
                else
                {
                    Response.Redirect("Page404.aspx");
                }
            }
