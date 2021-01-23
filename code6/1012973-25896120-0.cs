    protected void Page_Load(object sender, EventArgs e)
    {
        if(FirstName.Visible && LastName.Visible && EmailAddress.Visible) 
        {
            //Code
        }
    }
    protected void UpdateFirstName(object sender, EventArgs e)
    {
        FirstName.Visible = true;
    }
