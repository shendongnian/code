    // For each of the cached elements
    foreach(LIstViewItem lvi in myListView.ItemsPanelRoot.Children) 
    {
        // Inside here I can get the base object used to fill the data template using:
        PhoneBookEntry pbe = lvi.Content as PhoneBookEntry;
        if(pbe.Name == "Norris")
            BeAfraid();
        // Or check if this ListViewItem is or not selected:
        bool isLviSelected = lvi.IsSelected;
        // Or, like I wanted to, get an UIElement to animate projection
        UIElement el = lvi as UIElement;
        if(el.Projection == null)
            el.Projection = new PlaneProjection();
        PlaneProjection pp = el.Projection as PlaneProjection;
        // Now I can use pp to rotate, move and whatever with this UIElement.
    }
