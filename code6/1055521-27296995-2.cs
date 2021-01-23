    List<Grid> grids = new List<Grid> { grid1, grid2, grid3, gridN ... };
    int gridIndex = 0;
    void Load() {
        grids.Shuffle(); // use the extension method linked below
    }
    void Button_Click_2(object sender, RoutedEventArgs e) {
        if (gridIndex >= grids.Count)
            return;
        if (gridIndex > 0) {
            grids[gridIndex - 1].Visibility = Visibility.Collapsed;
        }
        grids[gridIndex].Visibility = Visibility.Visible;
        gridIndex++;
    }
