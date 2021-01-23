    public class Facility : IEquatable<Facility>
    {
        public int Id {get; private set;}
        //The rest of the properties
        public bool Equals(Facility other)
        {
            return other.Id == Id;
        }
    }
