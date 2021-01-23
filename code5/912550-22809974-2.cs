    public class HoteAvailComparer: IEqualityComparer<HoteAvail>
    {
        public bool Equals(HoteAvail x, HoteAvail y)
        {
            return x != null && y != null && x.HotelID == y.HotelID;
        }
        public int GetHashCode(HoteAvail obj)
        {
            return obj.HotelID;
        }
    }
