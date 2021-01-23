    protected void gvRoles_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            // get the row values
            Label Id = (Label)gvRoles.Rows[e.RowIndex].FindControl("lblIDEdit");
            TextBox Name = (TextBox)gvRoles.Rows[e.RowIndex].FindControl("tbName");
            // get the role from the db
            var thisRole = context.Roles.Where(r => r.Id.Equals(Id.Text, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            // modify the value
            thisRole.Name = Name.Text;
            // edit the role
            context.Entry(thisRole).State = System.Data.Entity.EntityState.Modified;
            // save the role
            context.SaveChanges();
            // get out of the edit mode
            gvRoles.EditIndex = -1;
            // reload the table data
            LoadData();
        }
