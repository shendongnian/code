      protected void DeleteRowHandler(object sender, CommandEventArgs e)
        {
            GridViewRow row = ((GridViewRow) ((LinkButton)sender).Parent.Parent);
            DataTable dt = = new DataTable();
        DataRow dr = null;
        dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
        dt.Columns.Add(new DataColumn("Column1", typeof(string)));
        dt.Columns.Add(new DataColumn("Column2", typeof(string)));
        dt.Columns.Add(new DataColumn("Column3", typeof(string)));
        for (int i = 0; i < Gridview1.Rows.Count; i++)
        {
            dr = dt.NewRow();
            dr[1] = ((TextBox)Gridview1.Rows[i].Cells[1].FindControl("TextBox1")).Text;
            dr[2] = ((TextBox)Gridview1.Rows[i].Cells[2].FindControl("TextBox1")).Text;
            dr[3] = ((TextBox)Gridview1.Rows[i].Cells[3].FindControl("TextBox1")).Text;
            dt.Rows.Add(dr);
        }
            dt.Rows.RemoveAt(row.RowIndex);
            ViewState["CurrentTable"] = dt;
            Gridview1.DataSource = dt;
            Gridview1.DataBind();
        } 
