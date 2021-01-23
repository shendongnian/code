    private void btnSimulate_MouseClick(object sender, EventArgs e) {
      using (SqlConnection con = svrConn) {
        using (SqlCommand cmd = new SqlCommand("myHelper_Simulate", con)) {
          cmd.CommandType = CommandType.StoredProcedure;
    
          cmd.Parameters.Add("@CCOID", SqlDbType.VarChar).Value = txtDUserCCOID.Text.Trim();
          cmd.Parameters.Add("@RVal", SqlDbType.VarChar).Value = "";
    
          con.Open();
          cmd.ExecuteNonQuery();
        }
      }
    }
