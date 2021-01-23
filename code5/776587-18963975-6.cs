    protected void ChkEnable_CheckedChanged(object sender, EventArgs e)
    {
      int selRowIndex = ((GridViewRow)(((CheckBox)sender).Parent.Parent)).RowIndex;
      var userId = gridView.DataKeys[selRowIndex].Value as string;
      if (string.IsNullOrWhiteSpace(userId)) return;
      var checkBox = gridView.Rows[selRowIndex].FindControl("chkEnable") as CheckBox;
      if (checkBox == null) return;
      var query = "update CreateUser set Enable= @Enabled where UserID='" + userid + "'";
      cmd = new SqlCommand(query, con);
      cmd.CommandType = CommandType.Text;
      cmd.Parameters.AddWithValue("Enabled", checkBox.Checked);
      cmd.ExecuteNonQuery();
      con.Close();
    
    } 
