    public int GetHashCode(AirClient obj)
    {
        if(obj.AirProduct == null) return 0;
        int hash = obj.AirProduct.PassengerNameRecord == null ? 0 : obj.AirProduct.PassengerNameRecord.GetHashCode();
        unchecked
        {
            foreach(var flight in obj.AirProduct.Flights)
            {
                hash = (hash * 31) + flight.MarketingAirlineCode == null ? 0 : flight.MarketingAirlineCode.GetHashCode();
                hash = (hash * 31) + flight.FlightNo == null ? 0 : flight.FlightNo.GetHashCode();
                hash = (hash * 31) + flight.DepartureDate.GetHashCode();
            }
        }
       return hash;
    }
 
