    var query = flights.SelectMany(f=>
                       new []{ string.Join("", f.Segments
                                     .Where(s=>s.DepartureDate > DateTime.Now)
                                     .Select(s=>
                                       string.Format("Departure: {0}, Arrival: {1}; ", s.DepartureDate, s.ArrivalDate))), Environment.NewLine});
    foreach(var e in query)
      Console.Write(e);
                
