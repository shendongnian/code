    from t in Assembly.GetExecutingAssembly().GetTypes()
    where t.IsClass && 
          (typeof(AbstractRequest<AResponse>).IsAssignableFrom(t) ||
           typeof(AbstractRequest<BResponse>).IsAssignableFrom(t))
    select t;
