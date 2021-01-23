    Grid g = new Grid();
    StackPanel sp = new StackPanel();
    for (int i = 0; i < NumberOfButtonsToBeCreated; i++)
    {
        RadioButton rb = new RadioButton();
        rb.GroupName = "myButtons";
        rb.Content = "text to display";
        sp.Children.Add(rb);
    }
    Grid.SetRow(sp, 2);
    Grid.SetColumn(sp, 2);
    g.Children.Add(sp);
