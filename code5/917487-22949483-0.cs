    string[] serialNumbers = searchModel.SerialNumbers.Split(',');
    // GetMethod defined at http://www.codeducky.org/10-utilities-c-developers-should-know-part-two/
    var stringContainsMethod = Helpers.GetMethod((string s) => s.Contains(default(string)));
    var serialNumberProperty = Helpers.GetProperty((Device d) => d.SerialNumber);
    var parameter = Expression.Parameter(typeof(Device));
    
    // generate a condition d.SerialNumber.Contains(sn) for each sn
    var conditions = serialNumbers.Select(sn => Expression.Call(  
        Expression.MakeMemberAccess(parameter, serialNumberProperty), // d.SerialNumber
        stringContainsMethod,
        Expression.Constant(sn) 
    ));
    // generate a lambda we can pass to Where: 
    // d => d.SerialNumber.Contains(sn1) || d.SerialNumber.Contains(sn1) || ..
    var predicate = Expression.Lambda<Func<Device, bool>>(
        // merge each condition with ORs
        conditions.Aggregate<Expression>((c1, c2) => Expression.OrElse(c1, c2)),
        parameter
    );
    // apply the predicate
    query = query.Where(predicate);
