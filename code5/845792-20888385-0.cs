    protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                DropDownList1.Items.Add("Item 1");
                DropDownList1.Items.Add("Item 2");
                DropDownList1.Items.Add("Item 3");
                DropDownList1.Items.Add("Item 4");
            }
        }
