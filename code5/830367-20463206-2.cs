    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string id = Request.QueryString["id"];
            // EDIT mode
            if (id == "Change_data_button")
            {
                DV.DefaultMode = DetailsViewMode.Edit;
            }
            // INSERT mode
            else if (id == "Register_button")
            {
                DV.DefaultMode = DetailsViewMode.Insert;
            }
        }
    }
    protected void DV_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
    {
        string username = e.Keys["username"].ToString();
    
        TextBox txtPassword = (TextBox)DV.FindControl("Password");
        string password = txtPassword.Text;
    
        string email = e.NewValues["userEmail"].ToString();
    
        RegisterUser.UpdateParameters["userPassword"].DefaultValue = password;
        RegisterUser.UpdateParameters["userEmail"].DefaultValue = email;
        RegisterUser.UpdateParameters["username"].DefaultValue = username;
    
        RegisterUser.Update();
    }
