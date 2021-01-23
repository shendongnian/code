    private void list_SelectedIndexChanged(object sender, EventArgs e)
    {
        var eModel = (EventModel)((ListView)sender).SelectedItem;
    
        var targets = GetEndPointTypesFromList(eModel);
        listView1.Items.Clear();
        foreach(var target in targets)
        {
            listview.Items.Add(target.Type.ToString());
        }
                
    }
