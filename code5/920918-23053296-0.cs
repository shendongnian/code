     public IQueryable GetAllCountry()
     {
        using (Context context = new Context())
        {
        var countries = context.COUNTRY.Select(c => new
         {
             country = new
              {
                  ID = c.ID,
                  Description = c.DESCRIPTION,
                  Currency = c.VFS_CURRENCY.CURRENCY_SYMBOL,
                  List<Language> = context.LANGUAGE.Where( l => l.Currency_ID ==c.COUNTRY.CURRENCY_ID}).ToList()//I just guess your LANGUAGE table has Currency_ID column
               }
             });
                return countries;
            }
        }
