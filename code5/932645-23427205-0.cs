        GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
        int id = Int32.Parse(GridView1.DataKeys[e.RowIndex].Value.ToString());
        TextBox tname = (TextBox)row.FindControl("txtFName");
        string firstName =tname.Text;
       
         Or
        string firstName = ((TextBox)row.FindControl("txtFName")).Text;
