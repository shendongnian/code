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
        }
    }
