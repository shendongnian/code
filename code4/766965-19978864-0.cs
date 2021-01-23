    private void GridViewName_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var GridState = sender as GridView;
        if(GridState.SelectedItems.Count>0)
        {
            // Do something
        }
    }
    
