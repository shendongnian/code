    private void handleWindowInitialized(object sender, EventArgs e)
    {
      // Add 3 rows and 3 columns.
      for (int i = 0; i < 3; i++)
      {
        gMain.ColumnDefinitions.Add(new ColumnDefinition());
        gMain.RowDefinitions.Add(new RowDefinition());
      }
    
      // Add button to each cell.
      for(int row=0; row<3; row++)
        for (int column = 0; column < 3; column++)
          createButton(row, column);
    }
