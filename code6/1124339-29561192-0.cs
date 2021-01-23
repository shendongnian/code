    // We build the expression x => x.[filtre]
    var parameter = Expression.Parameter(typeof(Contact));
    var property = Expression.Property(parameter, filtre);
    var expression = Expression.Lambda(property, parameter); // Returns a Expression<Func<Contact, typeof(propertyName)>>
    // The "right" overload of OrderBy, in a "safe" way
    var orderby = (from x in typeof(Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                  where x.Name == "OrderBy" && x.IsGenericMethod
                   let genericArguments = x.GetGenericArguments()
                   let parameters = x.GetParameters()
                   where genericArguments.Length == 2 && parameters.Length == 2 &&
                        parameters[0].ParameterType == typeof(IQueryable<>).MakeGenericType(genericArguments[0]) &&
                        parameters[1].ParameterType == typeof(Expression<>).MakeGenericType(typeof(Func<,>).MakeGenericType(genericArguments[0], genericArguments[1]))
                   select x).Single();
    // We build from OrderBy<,> the OrderBy<Contact, typeof(filtre)>
    orderby = orderby.MakeGenericMethod(typeof(Contact), expression.ReturnType);
    // We invoke OrderBy<Contact, typeof(filtre)>
    IQueryable<Contact> ordered = (IQueryable<Contact>)orderby.Invoke(null, new object[] { bdContext.Contact, expression });
    var contacts = ordered.ToList();
