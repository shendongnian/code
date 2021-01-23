    public async Task<JsonResult> GetFlights(string json, DateTime DepartureDate, DateTime ReturnDate)
    {
        var prices = await tr.GetPrices(User.Identity.Name, psw, json, DepartureDate, ReturnDate);
        ...
    }
