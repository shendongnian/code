    var param = Expression.Parameter(typeof(T), "p");
    		Expression body = param;
    		body = Expression.MakeMemberAccess(Expression.PropertyOrField(body, pi.Name), pi.PropertyType.GetMember("Value").First());
    		return Expression.Lambda(body, param);
 
