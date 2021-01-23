protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
           
DropDownList dr = (DropDownList)GridView1.Rows[e.RowIndex].FindControl("DropYearEdit");
             string st = dr.SelectedValue;    
             string sr = dr.SelectedItem.Text;
> // Manually change the inner value of required field
             **e.NewValues["year"] = st;**
        }
    </code>
Now the changed value is going to the database..
