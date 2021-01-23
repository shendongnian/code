    var dataGrid = new DataGrid();
    dataGrid.ItemsSource = BuildDataGrid();
    dataGrid.ItemContainerGenerator.StatusChanged += (s, e) =>
        {
           if (dataGrid.ItemContainerGenerator.Status == 
                               GeneratorStatus.ContainersGenerated)
           {
              var row = (DataGridRow)dataGrid.ItemContainerGenerator
                                                   .ContainerFromIndex(0);
              row.Background = Brushes.Red;
           }
        };
