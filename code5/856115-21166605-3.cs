    protected void StatusCheckBoxListChanged(object sender, System.EventArgs e)
    {
        if(SelectAll != StatusCheckBoxList.Items[0].Selected){
            SelectAll = !SelectAll;
            foreach(var li in StatusCheckBoxList.Items){
                li.Selected = SelectAll;
            }
        }
    }
