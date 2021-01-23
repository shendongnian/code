    protected void Page_Load(object sender, EventArgs e)
    {
        DropDownList loDDL1 = new DropDownList();
        loDDL1.ID = "ddl1";
        loDDL1.AutoPostBack = true;
        loDDL1.Items.Add(new ListItem("one", "1"));
        loDDL1.Items.Add(new ListItem("two", "2"));
        loDDL1.SelectedIndexChanged += new EventHandler(loDDL1_SelectedIndexChanged);
        Label1.Controls.Add(loDDL1);
        DropDownList loDDL2 = new DropDownList();
        loDDL2.ID = "ddl2";
        loDDL2.AutoPostBack = true;
        loDDL2.Items.Add(new ListItem("three", "3"));
        loDDL2.Items.Add(new ListItem("four", "4"));
        loDDL2.SelectedIndexChanged += new EventHandler(loDDL2_SelectedIndexChanged);
        Label1.Controls.Add(loDDL2);
    }
    void loDDL1_SelectedIndexChanged(object sender, EventArgs e)
    {
        // your code
    }
    void loDDL2_SelectedIndexChanged(object sender, EventArgs e)
    {
        // your code
    }
