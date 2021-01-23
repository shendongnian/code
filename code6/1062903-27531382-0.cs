    public void MyItemClick(object sender, EventArgs e)
    {
        var clickedMenuItem = (MenuItem)sender;
        var clickedHistoryItem = (History)clickedMenuItem.DataContext;
        //do stuff with whatever "guy" was clicked
    }
