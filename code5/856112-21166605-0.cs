    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostback){
            SelectAll = StatusCheckBoxList.Items.Cast<ListItem>().FirstOrDefault(d => d.Text == "Select All" && d.Selected) != null;
            
        }
    }
