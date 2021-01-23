    private void btnSimulate_MouseClick(object sender, EventArgs e) {
      using (SqlConnection con = svrConn) {
        using (SqlCommand cmd = new SqlCommand("myHelper_Simulate", con)) {
          cmd.CommandType = CommandType.StoredProcedure;
    
          cmd.Parameters.Add("@CCOID", SqlDbType.VarChar).Value = txtDUserCCOID.Text.Trim();
          var output = new SqlParameter("@RVal", SqlDbType.VarChar);
          output.Direction = ParameterDirection.Output;
          cmd.Parameters.Add(output);
    
          con.Open();
          cmd.ExecuteNonQuery();
        }
      }
    }
