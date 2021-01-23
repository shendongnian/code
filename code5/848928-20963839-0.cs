    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
    
        month.Items.Insert(0, new ListItem("", ""));
        day.Items.Insert(0, new ListItem("", ""));
        year.Items.Insert(0, new ListItem("", ""));
    
        SelectedDate = String.Empty;
        month.SelectedValue = String.Empty;
        day.SelectedValue = String.Empty;
        year.SelectedValue = String.Empty;
    }
