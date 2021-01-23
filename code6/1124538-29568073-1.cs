    protected void MyGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
           if(e.Row.RowState == DataControlRowState.Edit)
           {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList DropDownList1 = e.Row.FindControl("DropDownList1") as DropDownList1;
                Label Laptop_Name = e.Row.FindControl("Laptop_Name") as Label;
                
                //one option
                DropDownList1.SelectedValue = Laptop_Name.Text;
                //however for this option to work, when dropdownlist1 is binded data, its DataValueField should be set to "Laptop_Name"
                //second option with foreach
                foreach(ListItem item in DropDownList1.Items)
                {
                    if(item.Text == Laptop_Name.Text)
                        item.Selected = true; //not sure if the syntax is correct
                }
             }         
          }
        }
