        Grid childGrid = new Grid();
        Grid Grdrow1 = new Grid();
        Grid Grdrow2 = new Grid();            
        childGrid.ColumnDefinitions.Add(new ColumnDefinition());
        childGrid.ColumnDefinitions.Add(new ColumnDefinition());
        childGrid.ColumnDefinitions.Add(new ColumnDefinition());
        for (int i = 0; i < 3; i++)
        {
            childGrid.RowDefinitions.Add(new RowDefinition()
            {
                Height = GridLength.Auto
            });
        }
        CheckBox chb = new CheckBox();
        chb.Content = "Checkbox";
        chb.Checked += (o, e) =>
        {
            TextBlock txt = new TextBlock();
            txt.Text = "Hello from second row";
            Grid.SetColumn(Grdrow1, 1);
            Grid.SetRow(Grdrow1, 1);
            Grdrow1.Children.Add(txt);
            Grdrow2.Opacity = 0;
            Grdrow1.Opacity = 1;
            childGrid.Children.Add(Grdrow1);
        };
        chb.Unchecked += (o, e) =>
        {
            TextBlock txt = new TextBlock();
            txt.Text = "Hello from third row";
            Grid.SetColumn(Grdrow2, 1);
            Grid.SetRow(Grdrow2, 2);
            Grdrow2.Children.Add(txt);
            Grdrow2.Opacity = 1;
            Grdrow1.Opacity = 0;
            childGrid.Children.Add(Grdrow2);
        };
        childGrid.Children.Add(chb);
        LayoutRoot.Children.Add(childGrid);
