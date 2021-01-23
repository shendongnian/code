    CheckBox chk = ((CheckBox)grid_attendence.FindControl("chbox") as CheckBox);
            if (chk.Checked)
            {
    
                st = "insert into atd(attend,stno,stname,status) values ('" + gvrow.Cells[0].Text + "','" + gvrow.Cells[1].Text + "','" + gvrow.Cells[2].Text + "',1)";
    
            }
    else
    {
                st = "insert into atd(attend,stno,stname,status) values ('" + gvrow.Cells[0].Text + "','" + gvrow.Cells[1].Text + "','" + gvrow.Cells[2].Text + "',0)";
    
    
    }
                cmd = new SqlCommand(st, cn);
                cmd.ExecuteNonQuery();
                Response.Write("Record inserted");
                cn.Close();
