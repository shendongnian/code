     protected void ddlPersons_SelectedItemChanged(object sender, EventArgs e)
        {
            //Label1.Text = "message";
            //this.GridView1.DataSource = Persons;
           // this.GridView1.DataBind();
           int ddlVal = Convert.toint32(ddlPersons.SelectedValue);
           BindGridUsingDdl(ddlVal); 
        }
    
     Public static void BindGridUsingDdl(int ddlVal)
       {
          //Your code to populate gridview 
           // Gridview.Datasource = filter your list according 
          // to selected value of dropdown.
       }
