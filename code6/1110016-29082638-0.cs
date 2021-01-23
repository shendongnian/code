    var obj = JArray.Parse(File.ReadAllText(url));
    dfd = obj.SelectMany(x => x["PriceItems"])
       .Select(a => new PricesViewModel.DepartureFlightsData {
           DepartureCity = a["CityFromName"].Value<string>(),
           DepartureAirport = a["AirportFromCode"].Value<string>(),
           DepartureDate = depDate,
           DepartureTime = a["DepartureTime"].Value<string>(),
           DepartureAirline = a["AirlineCode"].Value<string>(),
           DepartureFlight = a["FlightNumber"].Value<string>(),
           DepartureFlightId = a["FlightID"].Value<string>(),
           Price = a["Price"].Value<int>(),
           Currency = a["Currency"].Value<string>()
       }).FirstOrDefault();
