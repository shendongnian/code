      protected void Page_Load(object sender, EventArgs e)
      {
    
        if (base.User.IsInRole("Person"))          
        {               
           
           tdPopup1.Visible=false;
        }
      }
      
