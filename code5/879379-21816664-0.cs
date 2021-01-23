    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack())
        {
          List<string> list = new List<string>
          { "Month", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12"};
    
        DropDownListMonth.DataSource = list;
        DropDownListMonth.DataBind();
        DropDownListMonth.SelectedIndex = 0;
    
        foreach (ListItem item in DropDownListMonth.Items)
        {
            int i = 0;
            string month = Convert.ToString(i);
            item.Value = month;
            i = Convert.ToInt32(month);
            i++;
        } 
      }  
    }
