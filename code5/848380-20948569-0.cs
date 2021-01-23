    protected void page_load()
    {
      if(!IsPostBack)
       {
         
         UpdatePanel1.Update();
       }
    txtName.Text="";
    }
