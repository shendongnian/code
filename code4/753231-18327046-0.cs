    protected void Button1_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("InsertIntoEmployee", con);
            cmd.CommandType = CommandType.StoredProcedure;            
            cmd.Parameters.Add("@LastName", SqlDbType.NVarChar(MAX)).Value = LastName.Text;
             cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar(MAX)).Value = FirstName.Text;
              cmd.Parameters.Add("@Phone1", SqlDbType.NVarChar(MAX)).Value = Phone1.Text;
             cmd.Parameters.Add("@Phone2", SqlDbType.NVarChar(MAX)).Value = Phone2.Text;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
    
          //  gvQuarterlyReport.DataBind();
        }
