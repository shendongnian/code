    public MyViewModel {
      get{
        return this.DataContext as MyViewModel;
      }
    }
    private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e) {
      // ... Get SelectedItems from DataGrid.
      var grid = sender as DataGrid;
      var selected = grid.SelectedItems;
    
      List<MyObject> selectedObjects = selected.OfType<MyObject>().ToList();
      
      MyViewModel.SelectedMyObjects = selectedObjects;
    }
