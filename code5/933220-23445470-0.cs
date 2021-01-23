    private void playersLongList_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.AddedItems.Count > 0)
        {
            Player p = e.AddedItems[0] as Player;
            string fname = p.FirstName;
            MessageBox.Show("hello"+fname);
        }
    }
