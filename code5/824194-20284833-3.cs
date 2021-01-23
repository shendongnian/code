    .Select(d => new DocumentUI
                     {
                         Title = d.Title,
                         Description = d.Description,
                         DateOfAdd = d.DateOfAdd,
                         ExpirationDate = d.ExpirationDate,
                         UserDoc = d.UserDoc,
                         User = new UserUI { 
                                       FirstName = d.User.FirstName, 
                                       LastName = d.user.LastName
                                   }
                     }).ToList(); 
