    public class Facility
    {
        public int Id {get; private set;}
        //The rest of the properties
    }
    public class FacilityIdsMatchEqualityComparer : IEqualityComparer<Facility>
    {
        public bool Equals(Facility x, Facility y)
        {
            return x.Id == y.Id;
        }
    }
