    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostback){
            SelectAll = StatusCheckBoxList.Items[0].Selected;
            foreach(var li in StatusCheckBoxList.Items){
                li.Selected = SelectAll;
            }
        }
    }
