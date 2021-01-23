     public void retrieve_client()
        {
            SqlConnection con = new SqlConnection(DBconnection.connectstr);
            con.Open();
            SqlCommand com = new SqlCommand("retrieve_client", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add("@name", SqlDbType.VarChar).Value = this.name;
            SqlDataAdapter da = New SqlDataAdapter(com);
            DataTable dt=New DatTable();
            da.Fill(dt);
            con.Close();
            GridView_clientbyname.DataSource=dt;
            GridView_clientbyname.DataBind();
    
        }
