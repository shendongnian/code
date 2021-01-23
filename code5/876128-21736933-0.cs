    var users = (from user in db.Users
                 join country in db.Countries on user.CountryID equals Country.ID into joinedList
                 from country in joinedList.DefaultIfEmpty()
                 select new {
                     user.UserID,
                     user.CreatedWhen,
                     user.UpdatedBy,
                     user.UpdatedWhen,
                     Country = (country == null ? null : new { country.CountryID, country.LocalName }),
                     Language = new { user.Language.LanguageID, user.Language.LocalName } }
                 })
                 .ToList();
