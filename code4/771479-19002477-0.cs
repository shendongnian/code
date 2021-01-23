    protected void insertButton_Click(object sender, EventArgs e)
    {
      GridViewRow row = (GridViewRow)((sender as Button).NamingContainer);
      // ...
      // then you can get your textboxes
      dr["id"] = ((TextBox)row.FindControl("txtNewId")).Text;
      dr["name"] = ((TextBox)row.FindControl("txtNewName")).Text;
    }
