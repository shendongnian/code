    private MySiteOracleRepository repo {get; set;}
    
    protected void Page_Load(object sender, EventArgs e)
    {
        repo = new MySiteOracleRepository(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
    
        if(!IsPostBack)
        {
            LoadUserInfo();
        }
    }
    
    protected void LoadUserInfo()
    {
        ApplicationUser user = repo.GetUserByUsername(UsernameLabel.Text);
        FirstNameLabel.Text = user.FirstName;
        LastNameLabel.Text = user.LastName;
    }
