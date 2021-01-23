    Web web =  null;
    if (myCondition)
    {
        //heavy operation
        web = site.openWeb();
    }
    
    for ( n loop)
    {
        //do stuff
        if (myCondition)
        {
            //use web
        }
    }
    
    if (myCondition)
    {
        web.Dispose()
    }
