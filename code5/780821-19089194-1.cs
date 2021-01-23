    var query = dbs.users.Where(x => x.useraccount.IsActive == IsActive);    
    switch (SearchBy)
    {
        case DTO::SearchBy.FirstName:
        {
            query = query.Where(x => string.Equals(x.FirstName, SearchText, StringComparison.InvariantCultureIgnoreCase)); 
            break;
        }
        case DTO::SearchBy.LastName:
        {
            query = Users.Where(x => string.Equals(x.LastName, SearchText, StringComparison.InvariantCultureIgnoreCase));
            break;
        }
        ...
    }
    query = query.Skip(skip).Take(take);
    return (from item in query
            orderby item.useraccount.CreatedDate
            select new DTO::User
            {
                LoginID = item.LoginID,
                FirstName = item.FirstName,
                LastName = item.LastName,
                MiddleName = item.MiddleName,
                Birhtday = item.userinfo != null ? item.userinfo.Birthday : DateTime.UtcNow
             }).ToList();
