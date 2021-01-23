    protected void Button1_Click(object sender, EventArgs e)
    {
       string conString = @"Data Source=FATTO-TOSH\SQLEXPRESS;Initial Catalog=Positions;Integrated Security=True";
	
       using (var con = new SqlConnection(conString))
       {
           var cmd = new SqlCommand("sys.sp_rename", con);
           con.Open();
           cmd.CommandType = CommandType.StoredProcedure;
           cmd.Parameters.AddWithValue("@objname", DropDownList1.SelectedValue)
                         .SqlDbType = SqlDbType.NVarChar;
           cmd.Parameters.AddWithValue("@newname", name.Text)
                         .SqlDbType = SqlDbType.NVarChar;
           cmd.ExecuteNonQuery();
       }
    }
