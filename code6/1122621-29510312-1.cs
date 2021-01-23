    public void CheckColumns(object _grid)
    {
            GridView tempGrid = _grid as GridView;
            foreach (var item in tempGrid.Columns)
            {
                item.IsChecked = false;
            }    
    }
