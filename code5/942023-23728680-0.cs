    ListBox ListA = new ListBox();
    ListBox ListB = new ListBox();
    
    Grid G = new Grid(); 
    PivotItem P = new PivotItem(); 
    
    //declare two columns with equal width (Width="*" for each)
    G.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
    G.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
    
    G.Children.Add(ListA);
    G.Children.Add(ListB);
    
    //set ListA in column 0 and ListB in column 1
    Grid.SetRow(ListA, 0);
    Grid.SetRow(ListB, 1);
    
     P.Content = G;
