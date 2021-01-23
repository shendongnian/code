    var instances = from t in Assembly.GetExecutingAssembly().GetTypes()
        where t.IsClass &&
              typeof(AbstractRequest).IsAssignableFrom(t) &&
              t.GetConstructor(Type.EmptyTypes) != null
        select Activator.CreateInstance(t) as AbstractRequest;
