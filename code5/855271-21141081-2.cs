    var todaysdate = DateTime.Today;
    DateTime dt;
    // use whatever format string matches appropriately
    if (DateTime.TryParseExact(acct.maturityDate, "YYYY-MM-dd HH:mm:ss"
                      , CultureInfo.InvariantCulture
                      , DateTimeStyles.None, out dt)
    {
        if (dt <= todaysdate)
        {
           maturityText.Visible = true;  
        }
    }
    
