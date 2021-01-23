    public partial class CountryEFSub : CountryEF
    {
    }
    public IEnumerable<CountryEF> GetAllCountry( )
    {
        using (Context context  = new Context() )
        {
            return context.COUNTRY.AsNoTracking().Select(c =>
                 new CountryEFSub()
                 {
                     ID = c.ID,
                     Description = c.DESCRIPTION,
                     CURRENCYEF = c.CURRENCYEF
                 }
            ).AsEnumerable();
        }
    }
