    public IQueryable<User> Search(String[] criteria)
            {
                var query = Database.Get<User>();
                List<User> res = new List<User>(); 
                foreach (String str in criteria)
                {
                    // Check if it is a phone number
                    
                    if (Regex.IsMatch(str, @"([0-9]{3})?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$"))
                    {
                        var users = query.Where(
                               u => u.PhoneNumber.ToLower() == (str))
                               .Select(i => new User
                               {
                                   Id = i.Id,
                                   UserName = i.Name,
                                   Email = null,
                                   PhoneNumber = i.PhoneNumber
                               });
    
                        // Multiple users can have the same phone so add all results
                        foreach (User u in users)
                        {
                            if (u != null) { res.Add(u); }
                        }
                       
                    }
                    // Check if it is an email match 
                    else if (str.Contains("@"))
                    {
                        var user = query.Where(
                               u => u.Email.ToLower() == (str))
                               .Select(i => new User
                               {
                               Id = i.Id,
                               UserName = i.Name,
                               Email = i.Email,
                               PhoneNumber = null
                           }).SingleOrDefault<User>(); // Only one user can use an email
    
                    if (user != null) { res.Add(user); }
                }
                // Otherwise it is a username
                // NOTE: If a username is all digits and dashes it won't be 
                // searched for because it is interpreted as a phone number!
                else
                {
                    var user = query.Where(
                           u => u.UserName.ToLower() == (str))
                           .Select(i => new User
                           {
                               Id = i.Id,
                               UserName = i.Name,
                               Email = null,
                               PhoneNumber = null
                           }).SingleOrDefault<User>(); // Only one user can use an email
    
                    if (user != null) { res.Add(user); }
                }
            }
    
            query = res.AsQueryable(); 
    
            // Group the results by username and id and return all information that was found
            query = from u in query
                    group u by new
                    {
                        u.Id,
                        u.UserName
                    } into g
                    select new User()
                    {
                        Id = g.Key.Id,
                        UserName = g.Key.UserName,
                        Email = g.Select(m => m.Email).SkipWhile(string.IsNullOrEmpty).FirstOrDefault(), 
                        PhoneNumber = g.Select(m => m.PhoneNumber).SkipWhile(string.IsNullOrEmpty).FirstOrDefault()
                    };
    
            return query;
        }
