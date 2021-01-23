    var users = (from user in db.Users
                 join country in db.Countries on user.CountryID equals country.ID into joinedList
                 from country in joinedList.DefaultIfEmpty()
                 select new {user, country})
                .ToList()   // your data fetched to memory by this line
                .Select(u => new
                {
                     u.user.UserID,
                     u.user.CreatedWhen,
                     u.user.UpdatedBy,
                     u.user.UpdatedWhen,
                     Country = (u.country == null ? null : new { u.country.CountryID, u.country.LocalName }),
                     Language = new { u.user.Language.LanguageID, u.user.Language.LocalName } }
                })
                .ToList();
