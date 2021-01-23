    public class FruitEqualityComparer : IEqualityComparer<Fruit>
    {
        public bool Equals(Fruit f1, Fruit f2)
        {
            if (f1.Name == f2.Name)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    
        public int GetHashCode(Fruit fruit)
        {
            return fruit.Name.GetHashCode();
        }
    }
