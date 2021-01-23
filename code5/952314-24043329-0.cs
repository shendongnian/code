    protected void MyButton_Click(object sender, EventArgs e)
    {
        foreach(GridViewRow row in gv_Rota.Rows)
        {
           DropDownList dd = row.FindControl("MyDropdown") as DropDownList;
    
           //OR
    
           DropDownList dd1 = row.Cells[0].FindControl("MyDropdown") as DropDownList;
           DropDownList dd2 = row.Cells[1].FindControl("MyDropdown") as DropDownList;
        }
    }
