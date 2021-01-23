    protected void Page_Load(object sender, EventArgs e)
    { 
        DropDownList o1 = new DropDownList();
        o1.Items.Add(new ListItem("Text1","Value1"));
        o1.Items.Add(new ListItem("Text2","Value2"));
        testdiv.Controls.Add(o1);
    }
