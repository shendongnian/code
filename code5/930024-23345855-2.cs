    for (int i = 0; i < dataGrid.Items.Count; i++ )
    {
     DataGridRow row = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromIndex(i);
     foreach (var gridColumn in dataGrid.Columns)
     {
      if(gridColumn.Header == "Something")
      {
        // Do something
      }
    }
