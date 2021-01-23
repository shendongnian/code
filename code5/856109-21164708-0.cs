    //class member variable
    bool _IsReady = true;
    //above loop
    _IsReady = false;
    
    for(int i = 0; i < StatusCheckBoxList.Items.Count; i++)
    {
        StatusCheckBoxList.Items[i].Selected = StatusCheckBoxList.Items.FindByValue("Select All").Selected;
    }
    // after loop
    _IsReady = true;
    // StatusCheckBoxList_SelectedIndexChanged begins with
    if (!IsReady)
    {
        return;
    }
