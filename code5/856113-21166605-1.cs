    protected void StatusCheckBoxListChanged(object sender, System.EventArgs e)
    {
        if(SelectAll != (StatusCheckBoxList.Items.Cast<ListItem>().FirstOrDefault(d => d.Text == "Select All" && d.Selected) != null)){
            SelectAll = !SelectAll;
            foreach(var li in StatusCheckBoxList.Items){
                li.Selected = SelectAll;
            }
        }
    }
