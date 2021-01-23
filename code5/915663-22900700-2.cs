    private void btnDisplay_Click(object sender, RoutedEventArgs e)
    {
        List<Game> data = theCatalogue.listPlatform();
        lstvwGames.Items.Clear();
        foreach (Game g in data)
        {
            lstvwGames.Items.Add(g.ToString());
        }         
    }
