    List<Grid> grids = new List<Grid> { grid1, grid2, grid3, gridN ... };
    int gridIndex = 0;
    void Load() {
        grids.Shuffle(); // use the extension method linked below
    }
    void Button_Click_2(object sender, RoutedEventArgs e) {
        if (gridIndex >= grids.Count)
            return;
        foreach(var grid in grids) {
            grid.Visibility = Visibility.Collapsed;
        }
        grids[gridIndex].Visibility = Visibility.Visible;
        gridIndex++;
    }
