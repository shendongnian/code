    var result=(from com in db.Company.AsEnumerable()
                        join c in db.Country.AsEnumerable() on com.CountryID equals c.CountryID
                        join s in db.State.AsEnumerable() on com.StateID equals s.StateID
                        join ct in db.City.AsEnumerable() on com.CityID equals ct.CityID
                        orderby com.Name
                        select new CompanyModel()
                         {
                             CompanyID = com.CompanyID,
                             Name = com.Name,
                             AddressLine1 = com.AddressLine1,
                             CountryID = com.CountryID,
                             StateID = com.StateID,
                             CityID = com.CityID,
                             Country = c.CountryID,
                             State = s.StateID,
                             City = ct.CityID,
                             Pin = com.Pin,
                             Phone = com.Phone,
    
                         }).Distinct().ToList();
