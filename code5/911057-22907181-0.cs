    /// <summary>
    /// Checks if current column contains graphic elements, focuses next cell of next column.
    /// </summary>
    /// <param name="dg">Source DataGrid</param>
    private static void CurrentCellChangedHandler(DataGrid dg)
    {
      if (isCurrentCellContainsGraphicElement(dg))
      {
        FocusNextCell(dg);
      }
    }
    /// <summary>
    /// Checks if current cell contains a graphic element.
    /// </summary>
    /// <param name="dg">Source DataGrid</param>
    /// <returns>true if current column contains graphic elements, else - false</returns>
    private static bool isCurrentCellContainsGraphicElement(DataGrid dg) 
    {
      var box = DataGridExcelNavigation.GetCellItem<TextBox>(dg.SelectedItem, dg.CurrentColumn);
    
      if (box != null) return false;
    
      return true;
    }
    private static T GetCellItem<T>(object item, DataGridColumn column) where T : class
    {
      if (item == null) return null;
    
      var cellData = (column.GetCellContent(item) as T);
      if (cellData == null)
      {
        var gridData = (column.GetCellContent(item) as Panel);
        if (gridData != null)
        {
          cellData = (gridData.Children.Where(x => x.GetType() == typeof(T)).FirstOrDefault() as T);
        }
      }
      return cellData;
    }
