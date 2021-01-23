    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            TextBox t = new TextBox();
            t.Text = "Vpiši";
            t.ID = "txt_123";
            PlaceHolder1.Controls.Add(t);
            t = new TextBox();
            t.Text = "Briši";
            t.ID = "txt_456";
            PlaceHolder1.Controls.Add(t);
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        TextBox tItem;
        String tValue;
        foreach (Control c in PlaceHolder1.Controls)
        {
            if (c.GetType() == typeof(TextBox))
            {
                tItem = (TextBox)c;
                tValue = tItem.Text;
            }
        }
    }
