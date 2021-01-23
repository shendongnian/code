    delegate ListViewItemCollection DelGetItems();
    
    ListViewItemCollection GetItems()
    {
        if(this.InvokeRequired)
        {
            this.Invoke(new DelGetItems(GetItems));
        }
        else
        {
             return lstFiles.Items;
        }
    }
