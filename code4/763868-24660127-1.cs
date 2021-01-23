    [WebMethod(Description = "Takes an internal trip ID as parameter.")] 
    public Trip GetTrip(int tripid) {
      try
      {
        var trip = Trip.GetTrip(tripid).Wait();
        return trip; 
      }
      catch(AggregateException ex)
      {
        throw ex.InnerException.First();
      }       
    }
