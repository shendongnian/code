    public class LangCountryModel 
    {
        public string LangCol1 { get; set; }
        public string LangCol2 { get; set; }
        public string CountryCol1 { get; set; }
        public string CountryCol2 { get; set; }
    }
    
         result = (from lang in my_entity.LANGUAGE
                                      join c in my_entity.COUNTRY
                                      on lang.COUNTRY_ID equals c.ID
                                      select new LangCountryModel 
                                      { 
                                           LangCol1 = lang.Col1,
                                           LangCol2 = land.col2,
                                           CountryCol1 = c.Col1,
                                           CountryCol2 = c.Col2
                                      }).ToList();
