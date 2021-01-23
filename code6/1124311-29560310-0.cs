    public class BookingVM
    {
      public List<FlightModel> FlightList { get; set; } // to display available flights
      public string Departure { get; set; } // bind to DepartureList
      public int FlightID { get; set; } // bind to FlightID in a dropdown that displays the arrival locations
      public int Seats { get; set; } // number of seats booked
      public SelectList DepartureList { get; set; } // unique departures
    }
