    public class UpsellSimpleComparer : IEqualityComparer<UpsellProduct>
    {
       public bool Equals(UpsellProduct x, UpsellProduct y)
       {
           return x.Id == y.Id && x.Id2 == y.Id2;
       }
       // sample, correct GetHashCode is a bit more complex
       public int GetHashCode(UpsellProduct obj)
       {
          return obj.Id.GetHashCode() ^ obj.Id2.GetHashCode();
       }
