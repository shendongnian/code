    var displayName = sk.GetValue("DisplayName");
    var size = sk.GetValue("EstimatedSize");
    ListViewItem item;
    if(displayName != null)
    {
        if(size != null)
             item = new ListViewItem(new string [] {displayName.ToString(), 
                                                           size.ToString()});
        else
             item = new ListViewItem(new string [] {displayName.ToString()});
        lstDisplayHardware.Items.Add(item);
    }
