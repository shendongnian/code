    public class AirClientComparer : IEqualityComparer<AirClient>
    {
        public bool Equals(AirClient lhs, AirClient rhs)
        {
            if (lhs == null || rhs == null) return false;
            if(object.ReferenceEquals(lhs, rhs)) return true;
            if(lhs.PassengerNameRecord != rhs.PassengerNameRecord) return false;
            if(object.ReferenceEquals(lhs.AirProduct, rhs.AirProduct)) return true;
            if(lhs.AirProduct == null || rhs.AirProduct == null) return false;
            if(object.ReferenceEquals(lhs.AirProduct.Flights , rhs.AirProduct.Flights )) return true;
            if(lhs.AirProduct.Flights.Count !=  rhs.AirProduct.Flights.Count) return false;
            if(lhs.AirProduct.Flights.Count == 0 && rhs.AirProduct.Flights.Count == 0) return true;
            return lhs.AirProduct.Flights.All(f =>
                rhs.AirProduct.Flights.Any(f2 =>
                        f.MarketingAirlineCode == f2.MarketingAirlineCode
                     && f.FlightNo == f2.FlightNo
                     && f.DepartureDate == f2.DepartureDate));
        }
        public int GetHashCode(AirClient obj)
        {
            if(obj.AirProduct == null) return 0;
            int hash = obj.AirProduct.PassengerNameRecord == null 
                      ? 17 : 17 * obj.AirProduct.PassengerNameRecord.GetHashCode();
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
    }
 
