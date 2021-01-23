    int totalRows = p.Parameter.Count() + p.Separator.Count(); 
    
    for (int i = 0; i < totalRows; i++) 
    { 
    var rowDef=new RowDefinition(); 
    rowdef.Height = new GridLength(1, GridUnitType.Auto); 
    myGrid.RowDefinitions.Add(rowDef); 
    
    }
