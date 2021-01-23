    public class FruitWeightComparer : IEqualityComparer<Fruit>
    {
       public bool Equals(Fruit one, Fruit two)
       {
            return one.Weight == two.Weight;
       }
       public int GetHashCode(Fruit item)
       {
            return one.Weight.GetHashCode();
       }
    }
