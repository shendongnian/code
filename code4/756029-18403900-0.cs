    string[] url = new string[2];
    foreach (string u in someCollection)
    {
       url[0] = someValue(u);
    }
    foreach (string u in someOtherCollection)
    {
        url[1] = someOtherValue(u);
    }
    ListViewItem item = new ListViewItem(url);
    listViewCookies.Items.Add(item);
