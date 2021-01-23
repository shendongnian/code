    var output = 
        f.Joined(Environment.NewLine, flight => 
            flight.Segments
                  .Where(s => s.DepartureDate > DateTime.Now)
                  .Joined("  ", s => "Departure: {0}, Arrival: {1};".Formatted(s.DepartureDate, s.ArrivalDate))
        );
    Console.Write(output);
