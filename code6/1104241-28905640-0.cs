    Expression predicateBody = Expression.Constant(false);
    Expression userParameter = Expression.Parameter("user", typeof(User));
    Expression userUserName = Expression.MakeMemberAccess(...);
    Expression userPhoneNumber = Expression.Cal(...);
    Expression userEmail = Expression.Call(...);
    
    foreach (String str in criteria)
    {
        // Check if it is a phone number
        if (Regex.IsMatch(str, @"([0-9]{3})?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$"))
        {
             predicateBody = Expression.Or(predicateBody, Expression.Equals(userPhoneNumber, Expression.Constant(str)));
        }
        // check if it is an email 
        else if (criteria.Contains("@"))
        {
             predicateBody = Expression.Or(predicateBody, Expression.Equals(userEmail, Expression.Constant(str)));
        }
        else
        {
             predicateBody = Expression.Or(predicateBody, Expression.Equals(userUserName, Expression.Constant(str)));
        }
    }
    
    return query.Where(Expression.Lambda<Func<User, bool>>(predicateBody, userParameter))
              .Select(i => new User()
                           {
                               Id = i.Id,
                               UserName = i.Name,
                           });
