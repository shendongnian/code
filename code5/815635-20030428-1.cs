    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["FirstName"] != null) FirstNameTextBox.Text = Session["FirstName"].ToString();
        if (Session["LastName"] != null) LastNameTextBox.Text = Session["LastName"].ToString();
        if (Session["City"] != null) CityDropDownList.SelectedValue = Session["City"].ToString();
        if (Session["State"] != null) StateDropDownList.SelectedValue = Session["State"].ToString();
    }
    
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        Session["FirstName"] = FirstNameTextBox.Text;
        Session["LastName"] = LastNameTextBox.Text;
        Session["City"] = CityDropDownList.SelectedValue;
        Session["State"] = StateDropDownList.SelectedValue;
    }
