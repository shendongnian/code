    public enum TCountry
    {
       tAustralia,
       tUnitedKingdom
    }
    public enum TCity
    {
       tSydney,
       tLondon
    }
    
    public abstract class TypeCountry
    {
        public abstract int Populate(string population);
    }
    
    public class TypeAust : TypeCountry
    {
        public override int Populate(string population)
        {
            // do your calculation with tAustralia, tSydney...
        }
    }
    
    public class TypeUK: TypeCountry
    {
        public override int Populate(string population)
        {
            // do your calculation with tUnitedKingdom, tLondon...
        }
    }
    
    public static class TypeCountryFactory
    {
        public static TypeCountry GetCountry(TCountry country)
        {
            switch (country)
            {
                case TCountry.tAustralia:
                    return new TypeAust();
                case TCountry.tUnitedKingdom:
                    return new TypeUK();
            }
        }
    }
    
    public int ProcessData (string population, int TCountry)
    {
        TypeCountry country = TypeCountryFactory.GetCountry(TCountry);
    
        return country.Populate(population);
    }
