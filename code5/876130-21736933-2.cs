    var users = (from user in db.Users
                 join country in db.Countries on user.CountryID equals country.ID into joinedList
                 from country in joinedList.DefaultIfEmpty()
                 select new {
                     user.UserID,
                     user.CreatedWhen,
                     user.UpdatedBy,
                     user.UpdatedWhen,
                     Language = new { user.Language.LanguageID, user.Language.LocalName },
                     Country = new { 
                         CountryID = country == null ? default(Guid) : country.CountryID,  // i assume type of CountryID is Guid
                         LocalName = country == null ? "" : country.LocalName 
                      }
                  })
                  .ToList();
