    FlagVariable output = FlagVariable.None;
    if( topping1.IsChecked )
    {
        output &= FlagVariable.Topping1;
    }
    if( topping2.IsChecked )
    {
        output &= FlagVariable.Topping2;
    }
    // etc...
    
