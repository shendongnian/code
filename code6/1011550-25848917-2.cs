    protected void Page_Load(object sender, EventArgs e)
    {
        //it's important to use this, otherwise textbox old value overrides again
        if (!IsPostBack)
        {
            Name.Text = "Some Value";
        }
    }
    protected void SubmitForm(object sender, EventArgs e)
    {
        var test = Name.Text; //now get new value here..
    }
