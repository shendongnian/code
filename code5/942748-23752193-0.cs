    // I can't find the docs for ListViewItem.Tapped right now - adjust the
    // type of the "handler" parameter to match the event
    public void CreateItem(string contentName, TappedEventHandler handler)
    {
        var item = new ListViewItem { Content = a };
        Main.Items.Add(item);
        item.Tapped += handler;
        ...
    }
