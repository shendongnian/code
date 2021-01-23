            protected void ddlgrid_SelectedIndexChanged(object sender, EventArgs e)
         {
             bindGridview();
             if (ddlgrid.SelectedValue == 1) // Dropdownlist Value 
             {
                  // Write your Sql Procedure or Query To Display result 
             
             //  It will return only selected value in Gridview.
             }
            if (ddlgrid.SelectedValue == 2)
             {
                 // same here 
             }
         }
