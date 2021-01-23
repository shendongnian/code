    public ActionResult Create()
    {
        IEnumerable<SiteBookingsTable> selectDeparture = new List<SiteBookingsTable>()
        {
            new SiteBookingsTable {listID = 0, departureAirport = "London (LTN)"},
            new SiteBookingsTable {listID = 1, departureAirport = "Manchester (MAN)"}
        };
        model = new SiteBookingsTable()
        model.selectDeparture = new SelectList(selectDeparture, "listID", "departureAirport");
        return View(model);
    }
