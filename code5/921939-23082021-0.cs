    public class Country ... etc..
         new Country() {                  ID = c.ID,
                            Description = c.DESCRIPTION,
                            CountryPhoneCode = c.COUNTRY_PHONE_CODE,
                            Currency = c.CURRENCY.CURRENCY,
                            Language = context.LANGUAGE.Where(l => l.COUNTRY_ID == c.ID).Select( l => new { lang = l.DESCRIPTION }).Distinct()
                        }
