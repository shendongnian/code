     protected void grvEmp_RowEditing(object sender, GridViewEditEventArgs e)
      {
        //Set the edit index.
        grvEmp.EditIndex = e.NewEditIndex;
        //Bind data to the GridView control.
        BindData();
      }
