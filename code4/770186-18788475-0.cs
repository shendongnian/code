    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            MonthSelectionDrop.Items.Add(new ListItem("--please select--", "0"));
            MonthSelectionDrop.Items.Add(new ListItem("January", "1"));
            MonthSelectionDrop.Items.Add(new ListItem("February", "2"));
            //and so on
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        MonthLabel.Text = MonthSelectionDrop.SelectedItem.Text;
    }
