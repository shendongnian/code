    public IEnumerable<string> FilterFlights(IEnumerable<Flight> flights)
    {
        foreach (var flight in flights)
        {
            var indexItem = 0;
            DateTime previousArrivalDateTime = new DateTime();
            TimeSpan timeSpan;
    
            int time = 0;
            foreach (var segments in flight.Segments)
            {
                if (indexItem == 0)
                {
                    previousArrivalDateTime = segments.ArrivalDate;
                    yield return "Departure: " + segments.DepartureDate + ", Arrival: " + segments.ArrivalDate + "; ";
                }
    
                if (indexItem > 0)
                {
                    timeSpan = segments.DepartureDate - previousArrivalDateTime;
                    time += timeSpan.Hours;
                    yield return "Departure: " + segments.DepartureDate + ", Arrival: " + segments.ArrivalDate + "; ";
                    previousArrivalDateTime = segments.ArrivalDate;
                }
                indexItem++;
            }
        }
    } 
