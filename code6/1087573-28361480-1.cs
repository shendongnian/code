       protected void gv_tList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
               Label descr=(Label)e.Row.FindControl("descr");
               string Mydescr=descr.Text
               string taskID = e.Row.Cells[0].Text;
               descr.Text = descr.Text.Length > 40 ? 
               descr.Text.Substring(0, 40) + ".." : descr.Text;
            }
        }
