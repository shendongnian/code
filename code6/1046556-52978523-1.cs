    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using YourSite.Models;
    using YourSite.ViewModels;
    namespace YourSite
    {
        public class Repository
        {
            Model1 db = new Model1();  // this is your DB Context
            // Currencies
            public List<Currencies> GetAllCurrencies()
            {
                return db.Currencies.OrderBy(e => e.Name).ToList();
            }
            // Countries
            public List<Countries> GetAllCountries()
            {
                return db.Countries.OrderBy(e => e.Name).ToList();
            }
        }
    }
