    protected void GridView1_PreRender(object sender, EventArgs e) 
    {
      if (GridView1.EditIndex != -1) 
      {
         //Just changed the index of cells based on your requirements
         DropDownList ddllist = (DropDownList)e.Row.FindControl("modeldropdownlist");
         ddllist.SelectedValue = DataBinder.Eval(e.Row.DataItem, "exammode").ToString();              
      }
    }
