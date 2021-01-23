    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
     {
         if(e.Row.RowType == DataControlRowType.DataRow)
         {
            var chk = (CheckBox)e.Row.FindControl("chkEnable");
            if (chk == null || !chk.checked) return; 
            var userId  =GridView1.DataKeys[row.RowIndex].Value as string;
            if (string.IsNullOrWhiteSpace(userId)) return;
            var query = "update CreateUser set Enable='False' where UserID='" + userid + "'";
            cmd = new SqlCommand(query, con);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            con.Close();
          }
    }
