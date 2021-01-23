        string eId = EmployeeIDTxt.Text;
        string query = String.Empty;
        query = "SELECT EMPL_SEQ_ID, EMPL_ID, EMPL_LAST_NM, EMPL_FIRST_NM, EMPL_PREFRD_NM"
        query &= "  FROM EMPL"
        query &= "  WHERE EMPL_SEQ_ID = @ID; "
    DataSet ds = new DataSet();
    using (SqlConnection conn = new SqlConnection(MyConn)) {  'myconn should be your connection string
    	using (SqlDataAdapter da = new SqlDataAdapter()) {  'SqlDataAdapter should be different if you're using OleDb or Oracle
    		da.SelectCommand = new SqlCommand(query, conn); 'See previous comment for SqlCommand
    		da.SelectCommand.Parameters.Add(new SqlParameter("@ID", eId)); 'Gives your parameter the value you feed it
    		da.Fill(ds); 'fill the dataset with the results from the query
    	}
    }
