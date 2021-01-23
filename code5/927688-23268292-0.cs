    foreach (GridViewRow gvrow in grid_attendence.Rows)
    {
        var chk = (CheckBox)gvrow.FindControl("chbox");
        if (chk.Checked)
        {
            st = "insert into atd(attend,stno,stname) values ('" + gvrow.Cells[0].Text + "','" + gvrow.Cells[1].Text + "','" + gvrow.Cells[2].Text + "')";
            cmd = new SqlCommand(st, cn);
            cmd.ExecuteNonQuery();
            Response.Write("Record inserted");
            cn.Close();
        }
    }
