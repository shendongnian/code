    var lineTypeComboBox = new ComboBox
             {
                Width = 40,
                Background = Background,
                Margin = new Thickness(0),
                Padding = new Thickness(0)
             };
    lineTypeComboBox.Items.Add(new Line { X1 = 1, X2 = 20, Y1 = 1, Y2 = 20, Stroke = new SolidColorBrush(Colors.Black) });
    //add ComboBox to StackPanel
    spMain.Children.Add(lineTypeComboBox);
