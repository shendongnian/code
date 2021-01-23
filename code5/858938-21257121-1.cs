    public class SharedPropertyEqualityComparer : IEqualityComparer<ISharedProperty>
    {
        public bool Equals(ISharedProperty x, ISharedProperty y)
        {
            // Add some logic to check for x and y null value
            return x.Date_Debut == y.Date_Debut &&
                   x.Date_Fin == y.Date_Fin &&
                   x.NombreJours == y.NombreJours;
        }
        public int GetHashCode(ISharedProperty x)
        {
            // Left for you to implement
        }
    }
