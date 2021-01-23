    private void createButton(int row, int column)
    {
      var button = new Button();
    
      // Add to gMain
      gMain.Children.Add(button);
    
      // Place the button in the correct cell.
      Grid.SetRow(button, row);
      Grid.SetColumn(button, column);
    			
      // Tie to the click event.
      button.Click += handleButtonClick;
    }
