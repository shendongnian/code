    public bool ExecuteQuery(String pQuery)
    {
        SqlConnection con = new SqlConnection("MyConnectionString");
        con.Open();
        try
        {
            SqlCommand cmd = new SqlCommand(pQuery, con);
            // if you pass just query text
            cmd.CommandType = CommandType.Text;
            // if you pass stored procedure name
            // cmd.CommandType = CommandType.StoredProcedure;   
            cmd.ExecuteNonQuery();
            con.Close();
            return true;
        }
        catch (Exception exp)
        {
            con.Close();
            MessageBox.Show(exp.Message, "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        return false;
    }
