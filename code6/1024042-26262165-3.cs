    var abstractRequestTypes =
        (from t in Assembly.GetExecutingAssembly().GetTypes()
         where t.IsClass &&
              typeof(IResponseData).IsAssignableFrom(t)
         select typeof(AbstractRequest<>).MakeGenericType(t)).ToList();
    var instanceTypes = from t in Assembly.GetExecutingAssembly().GetTypes()
        where t.IsClass &&
              abstractRequestTypes.Any(dt => dt.IsAssignableFrom(t));
