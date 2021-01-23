    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           myButton.Attributes.Add("onclick", "self.location.replace('your_new_page.aspx')");
        }
    }
