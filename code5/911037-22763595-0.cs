      Protected void GridView1_DataBound(Object sender, eventArgs e)
    {
       foreach(GridViewRow r in GridView1.Rows)
        {
          DropDownList ddlSelection= new DropDownList();
          ddlSelection.Items.Add(new ListItem("one"));
          ddlSelection.Items.Add(new ListItem("two"));
          r[1].Controls.Add(ddlSelection);
        }
    }
    
         
