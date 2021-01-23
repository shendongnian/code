    int NewItemsCount = 0;
    for (int i = 0; i<XmlDataProvider.Items.Count; i++)
    {
        bool IsOld=false;
    //Loop throu all items in existing
        for (int o =0; i<NewData.Items.Count;i++)
        {
            if(XmlDataProvider.Items[i].ID==NewData.Items[o].ID)
            {
                IsOld = true;
                break;
            }
        }
        if(!IsOld)
        {
             NewItemsCount++;
        }
    }
