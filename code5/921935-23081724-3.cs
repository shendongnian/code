    public List<CountryVm> GetAllCountry()
    {
    using (Context context = new Context())
                {
                    var countries = (from c in context.COUNTRY
                                    select new CountryVm
                            {
                             ID = c.ID,
                             Description = c.DESCRIPTION,
                             CountryPhoneCode = c.COUNTRY_PHONE_CODE,
                             Currency = c.CURRENCY.CURRENCY,
                             Language = context.LANGUAGE
                                        .Where(l => l.COUNTRY_ID == c.ID)
                                        .Select( l => new { lang = l.DESCRIPTION }).Distinct()
                        }).ToList<CountryVm>();
                    }
    
                    return countries;
    }
   
