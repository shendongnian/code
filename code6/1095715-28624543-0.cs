    MyItem itemToCopy = listView1.SelectedItem; //Or where ever your item comes from
    if(!listView2.Items.contains(itemToCopy)
    {
        listView2.Items.add(itemToCopy);
    }
    else
    {
        // Item is already in the list
    }
