    var query = dbs.users.Where(x => x.useraccount.IsActive == IsActive);    
    switch (SearchBy)
    {
        case DTO::SearchBy.FirstName:
        {
            query = query.Where(x => string.Equals(x.FirstName, SearchText, StringComparison.CurrentCultureIgnoreCase); 
            break;
        }
        ...
    }
    return (from item in query
            select new DTO::User
            {
                LoginID = item.LoginID,
                FirstName = item.FirstName,
                LastName = item.LastName,
                MiddleName = item.MiddleName,
                Birhtday = item.userinfo != null ? item.userinfo.Birthday : DateTime.UtcNow
             }).ToList();
    query = query.Skip(skip).Take(take);
