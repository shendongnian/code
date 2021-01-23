    //container for the first item of the pair
    List<string> typedUrls = new List<string>(); 
    foreach (string u in someCollection)
    {
       typedUrls.Add(someValue(u));
    }
    //container for the second item of the pair
    List<string> times = new List<string>(); 
    foreach (string u in someOtherCollection)
    {
        times.Add(someOtherValue(u));
    }
    //now loop the containers, and construct a string[] for each
    //assuming that they have the exact same length
    for (int i = 0; i < typedUrls.Count; i++)
    {
        //create a string[]
        string[] stringItem = { typedUrls[i], times[i]};
        //construct a ListViewItem
        ListViewItem item = new ListViewItem(stringItem);
        //add it to the listView
        listViewCookies.Items.Add(item);
    }
