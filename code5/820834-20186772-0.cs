     protected void GridView1_OnRowEditing(object sender, GridViewEditEventArgs e)
           {
            GridViewRow row = GridView1.Rows[e.NewEditIndex];
            bool IsChecked = ((CheckBox)(row.Cells[0].FindControl("chkbox"))).Checked;
           }
