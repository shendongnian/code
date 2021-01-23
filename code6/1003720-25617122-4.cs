    protected void gridview1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
          
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //ShowColumn Check
            if (CheckBox2.Checked)
            {
                e.Row.Cells[2].Visible = false;
            }
            else
            {
                e.Row.Cells[2].Visible = true;
            }
            //ShowRow Check
            var myCheckbox = e.Row.Cells[0].Controls[1] as CheckBox; // ONLY if your Checkbox in the FIRST column!!!!
            if (myCheckbox != null && !myCheckbox.Checked)
            {
                e.Row.Visible = false;
            }
        }
    }
