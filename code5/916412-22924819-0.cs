    protected void Save_btn_Click(object sender, EventArgs e)
    {
        SqlTransaction trn = null;
        try
        {
             con.Open();
             trn = con.BeginTransaction();
             cmd = new SqlCommand("insert into....; SELECT SCOPE_IDENTITY()", con, trn);
             int Regid = Convert.ToInt32(cmd.ExecuteScalar());
             cmd = new SqlCommand("insert into....", con, trn);
             cmd.Parameters.AddWithValue("@RegNo", Regid);
             cmd.ExecuteNonQuery();
             cmd = new SqlCommand("insert into....", con, trn);
             cmd.Parameters.AddWithValue("@RegNo", Regid);
             cmd.ExecuteNonQuery();
             trn.Commit();
         }
        catch (Exception ex)
        {
            lbl_ErrorMsg.Text = ex.Message;
            trn.Rollback();
        }
