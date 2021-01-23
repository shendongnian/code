    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ArrayList values = new ArrayList();
    
            values.Add("James");
            values.Add("Bob");
            values.Add("Joe ");
            values.Add("Banana");
            values.Add("Frank");
    
            Repeater1.DataSource = values;
            Repeater1.DataBind();
        }
    }
