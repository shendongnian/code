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
                    Language = c.Languages.Select( l => new { l.Description /* desired field from LANGUAGE */ } )
                }
            });
            return countries;
        }
    }
