    void gv_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ImageButton btnUpdate = new ImageButton();
            btnUpdate.Click += btnUpdate_Click;
            TableCell tc = new TableCell();
    
            tc.Controls.Add(btnUpdate);
            e.Row.Cells.Add(tc);
        }
    }
    
    void gv_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {    
            ImageButton btnUpdate = (ImageButton)e.Row.FindControls("btnupdate") 
            btnUpdate.ID = "btnupdate";
            btnUpdate.ImageUrl = "~/SmartAdmin/Images/update.png";
            btnUpdate.ToolTip = "Click Update";
            btnUpdate.CommandName = "update";
        }
    }
