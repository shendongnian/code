    if (strVal == "today")
    {
        //dtStart = Convert.ToInt32(ddlFilter.SelectedValue)
        dtStart = DateTime.Today;
        dtEnd = DateTime.Today;
    }
    if (strVal == "weekly")
    {
        dtStart = DateTime.Now.AddDays(-7).Date;
        dtEnd = DateTime.Today;
    }
    if (strVal == "byweekly")
    {
        dtStart = DateTime.Now.AddDays(-15).Date;
        dtEnd = DateTime.Today;
    }
    if (strVal == "monthly")
    {
        dtStart = DateTime.Now.AddMonths(-1).Date;
        dtEnd = DateTime.Today;
    }
    if (strVal == "yearly")
    {
        dtStart = DateTime.Now.AddYears(-1).Date;
        dtEnd = DateTime.Today;
    }
    if (strVal == "custom")
    {
        dtEnd = DateTime.Today;
        lbldtStart.Visible = true;
        txtdtStart.Visible = true;
        lbldtEnd.Visible = true;
        txtdtEnd.Visible = true;
    }
    
    // Check either Datetime have value or its null.
    if (dtEnd.HasValue)
    {
        FillGridFilter(dtStart, dtEnd);
    }
    
