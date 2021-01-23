    int numericValue;
    if(Int32.TryParse(tetBoxPrijs.Text, out numericValue))
    {
        //valid, use in query
    }
    else
    {
        //not numeric, inform the user
    }
