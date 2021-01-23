    protected void Page_Load(object sender, EventArgs e)
        {
            //Don't do this here!
            //DropDownList ShowAssumptions = new DropDownList();
    
            List<string> list = new List<string>()
            {
                "test",
                "test2"
            };
            this.ShowAssumptions.DataSource = from i in list
                                         select new ListItem()
                                         {
                                             Text = i,
                                             Value = i
                                         };
            this.ShowAssumptions.DataBind();
        }
