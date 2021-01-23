    protected void MyButton_Click(object sender, EventArgs e)
    {
        foreach(GridViewRow row in gv_Rota.Rows)
        {
           //find this control in this row
           DropDownList dd = row.FindControl("MyDropdown") as DropDownList;
    
           //OR
           //find this control in a specific cell
           DropDownList dd1 = row.Cells[0].FindControl("MyDropdown") as DropDownList;
           DropDownList dd2 = row.Cells[1].FindControl("MyDropdown") as DropDownList;
           //this is just a pseudo-code to determine which dropdown was selected per row. 
           //You can improve on this
           if(dd1.SelectedValue != string.Empty)
             thisDay.SelectedWeek = dd1.SelectedValue;
           else if(dd2.SelectedValue != string.Empty)
             thisDay.SelectedWeek = dd2.SelectedValue;
           ....
        }
    }
