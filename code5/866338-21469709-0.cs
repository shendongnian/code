    public class Beer
    {
        public int BeerID { get; set; }
        public string Name { get; set; }
        //public virtual ICollection<Company> Companies { get; set; }  // one beer could have many companies
    
    }
    
    public class Company
    {
        public int CompanyID { get; set; }
        public string Name { get; set; }
    
        // Navigation Property
        // public virtual ICollection<Beer> Beers { get; set; }  // this is what I forgot, a co
    }
