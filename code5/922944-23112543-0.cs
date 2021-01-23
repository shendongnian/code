           SiteViewModel siteViewModel = (
                from site in context.Sites
                join address in context.Addresses on site.AddressID equals address.AddressID
                join country in context.Countries on address.CountryID equals country.CountryID into joinedCountry
                from country in joinedCountry.DefaultIfEmpty()
                join state in context.States on address.StateID equals state.StateID into joinedState
                from state in joinedState.DefaultIfEmpty()
                where site.SiteID == siteID
                select new SiteViewModel
                {
                    SiteID = site.SiteID,
                    Name = site.Name,
                    AddressID = address.AddressID,
                    Address1 = address.Address1,
                    Address2 = address.Address2,
                    City = address.City,
                    //CityID = city.CityID,
                    State = state,
                    StateID = state.StateID,
                    Country = country,
                    CountryID = country.CountryID,
                    ZIP = address.ZIP
                }
            ).FirstOrDefault();
            return siteViewModel;
