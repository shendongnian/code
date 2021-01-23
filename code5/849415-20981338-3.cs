    public ActionResult Index()
    {
        Teetimes r = BookingManager.GetBookings();
        return new JsonWithoutNullPropertiesResult(t);
    }
