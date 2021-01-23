    var listView = FindViewById<ListView>(Resource.Id.MyListView);
    listView.ItemLongClick += listView_ItemLongClick;
    private void listView_ItemLongClick(object sender, AdapterView.ItemLongClickEventArgs e)
    {
        // Do your stuff here
    }
