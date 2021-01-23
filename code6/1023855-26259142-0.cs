            GridViewRow row = (GridViewRow)gvExcelFile.Rows[e.RowIndex];
            TextBox TxtEditName = (TextBox)row.FindControl("TxtEditName");
            TextBox TxtEditValue = (TextBox)row.FindControl("TxtEditValue");
    
            string enm = TxtEditName.Text;
            string evl = TxtEditValue.Text;
            int editindex = gvExcelFile.EditIndex;
            int currentindex = e.RowIndex;
             string editquery = "UPDATE [Sheet1$] set Sheet1$A"+currentindex+"=? ,Sheet1$B"+currentindex+"=?";
            gvExcelFile.EditIndex = -1;
            conn.Open();
    
           
            OleDbCommand editcmd = new OleDbCommand(editquery, conn);
            editcmd.Parameters.AddWithValue("Sheet1$A"+currentindex, enm);
            editcmd.Parameters.AddWithValue("Sheet1$B"+currentindex, evl);
            editcmd.ExecuteNonQuery();
            conn.Close();
            gvbind();
