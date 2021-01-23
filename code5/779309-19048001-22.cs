    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)//Only do this first time it's loaded
        {
           TextBoxFirstName.Text = Person.FirstName;
           TextBoxLastName.Text = Person.LastName;
        }
    }
