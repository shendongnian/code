    public class FruitWeightComparer : IEqualityComparer<Fruit>
    {
        public bool Equals(Fruit x, Fruit y)
        {
            if(x == null || y== null) return false;
            if (Object.ReferenceEquals(x, y)) return true;
            return x.Weight == y.Weight;
        }
        public int GetHashCode(Fruit obj)
        {
            return obj.Weight == null ? 0 : obj.Weight.GetHashCode();
        }
    }
