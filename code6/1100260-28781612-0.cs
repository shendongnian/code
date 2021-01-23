    if (sqlr.HasRows)
    {
        //Calculate accounting period adjustment.
        yearEndDiff = 12 - Convert.ToInt32(sqlr.GetDateTime(5).Month);
        // Instantiate array
        SessionHelper.CompDetails = new object[11];
        //Company Code.
        SessionHelper.CompDetails[0] = sqlr.GetInt32(0);
        // etc
