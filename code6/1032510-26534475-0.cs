    protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
              setAdminMenu();
            }
        }
    
     private void setAdminMenu()
        {
          if(f.pass.Equals(txtpass.Value))
          {
            abc.Visibility = visible;
          }
        }
