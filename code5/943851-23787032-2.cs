    var cm = new ContextMenu();
    var disableItem = new MenuItem
    {
        Header = "Disable",
        Command = new DelegateCommand((parameter) =>
            {
                (parameter as MenuItem).IsEnabled = false;
            })
    };
    disableItem.CommandParameter = disableItem;
    cm.Items.Add(disableItem);
    this.ContextMenu = cm;
