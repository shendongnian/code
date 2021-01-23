    public void ShowButton_click(object sender, EventArgs e)
    {
       int MyId = int.Parse(((Button)sender).CommandParameter.ToString());
       Tile TileIWasSearchingFor = (from t in tiles where t.ID == MyId select t).First();
    // do something with tile You found
    }
