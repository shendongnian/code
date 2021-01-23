    @helper DisplayDate(DateTime dt)
    {
        if(dt.HasValue)
        {
            dt.Value.ToShortDateString();
        }
        else
        {
            "No Date Available";
        }
    }
