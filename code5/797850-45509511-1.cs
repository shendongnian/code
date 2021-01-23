    public DbSet<SCountry> country { get; set; }
        public List<SCountry> DoDistinct()
        {
            var query = (from m in country group m by new { m.CountryID, m.CountryName, m.isactive } into mygroup select mygroup.FirstOrDefault()).Distinct();
            var Countries = query.ToList().Select(m => new SCountry { CountryID = m.CountryID, CountryName = m.CountryName, isactive = m.isactive }).ToList();
            return Countries;
        }
