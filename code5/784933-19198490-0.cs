    private void Bind()
    {
    
        var dt = YourFunctionReturningDataTable(); 
        //Assuming your table has two columns Id,Name
        
        dropdownlist1.datasource = dt;
        dropdownlist1.DataTextField = "Name";
        dropdownlist1.DataValueField="Id";
        dropdownlist1.DataBind();
        dropdownlist1.Items.Insert(0, new ListItem("---Select---","-1"));
    }
    
    private void Page_Load()
    {
      
    
      if(!IsPostback)
      {
      Bind();   
      }
    }
