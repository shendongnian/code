    protected void Session_End(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand("check_if_closed", con);
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@user_id", txtUname.Text);
                            con.Open();
                            cmd.ExecuteNonQuery();
    }
