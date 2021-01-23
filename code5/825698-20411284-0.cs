    private void TxtBox1_TextChanged(object sender, TextChangedEventArgs e)
    {
        RaiseEvent(new RoutedEventArgs(MyTextChanged, sender));
    }
		
    // For demo only: simulate selecting the grid row
    // You will have to roll your own logic here
    // ***NEVER code like this, very bad form***
    private void Grid_TextChanged(object sender, TextChangedEventArgs e)
    {
        var textBox = e.Source as TextBox;
        if (textBox == null) return;
        var txt = textBox.Text;
        switch (txt)
        {
            case "a":
                _myGrid._dataGrid.SelectedIndex = 0;
                break;
            case "g":
                _myGrid._dataGrid.SelectedIndex = 1;
                break;
            case "o":
                _myGrid._dataGrid.SelectedIndex = 2;
                break;
            case "p":
                _myGrid._dataGrid.SelectedIndex = 3;
                break;
        }
    }
