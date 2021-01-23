    public class CountryViewModel
    {
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public static IQueryable<CountryViewModel> GetCountries()
        {
            using (DbEntities _context = new DbEntities())
            {
                var featureCode = "PCLI";
            
                var countries = _context.country
                    .Where(c => c.Feature_Code == featureCode)
                    .Select(c => new CountryViewModel
                    {
                        CountryCode = c.Country_Code,
                        CountryName = c.Name
                    }
                );
                return countries;
            }
        }
    }
