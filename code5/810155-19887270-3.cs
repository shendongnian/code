    int statusID =0;
    
    if(Session["statusID"] != null && int.TryParse(Session["statusID"].ToString(), out statusID) && statusID ==1)
    {
        using(SqlConnection con = new SqlConnection(ConnectionString))// set ConnectionString
        {
            using(SqlCommand cmd = new SqlCommand("update tblstatus set statusID=2 where      expenesesid=@expensesid",con)) // set appropriate query
            {
                sqldatadapter da=new sqldatadapter(cmd) ;
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
