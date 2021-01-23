    EventManager manager = new EventManager();
    try
    {
        EventDates = manager.GetWhatsOn(Request.QueryString["category"]);
        rptEventDates.DataSource = EventDates;
        rptEventDates.DataBind();
    }
    finally
    {
        manager.Dispose();
    }
