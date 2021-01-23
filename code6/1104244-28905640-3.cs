    var phoneNumbers = new List<string>();
    var emails = new List<string>();
    var userNames = new List<string>();
    
    foreach (var str in criteria)
    {
        // Check if it is a phone number
        if (Regex.IsMatch(str, @"([0-9]{3})?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$"))
        {
             phoneNumbers.Add(criteria);
        }
        // check if it is an email 
        else if (criteria.Contains("@"))
        {
             emails.Add(crietria);
        }
        else
        {
             userNames.Add(criteria);
        }
    }
    
    return query.Where(u => phoneNumbers.Contains(u.PhoneNumber)
           || emails.Contains(u.Email)
           || userNames.Contains(u.UserName))
           .GroupBy(u => u.Id)
           .Select(users => new User()
                  {
                       Id = users.Key,
                       UserName = users.FirstOrDefault(u => u.UserName),
                       Email = users.FirstOrDefault(u => u.Email),
                       PhoneNumber = users.FirstOrDefault(u => u.PhoneNumber)
                  });
        
