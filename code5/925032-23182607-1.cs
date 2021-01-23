    select new PortFolio
                         {
                            countryId= grp.Key.CountryId,
                            PortfolioTypeId= grp.Key.PortfolioTypeId,
                            UserId= grp.Key.UserId,
                            //Add others members with default value
                            Titel=string.Empty;
                            ....  
                         }).ToList();
