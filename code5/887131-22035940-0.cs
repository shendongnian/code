    var type = typeof(TPresenter);
    var constructor = type.GetConstructors()
                          .FirstOrDefault(c => 
                              (c.GetParameters().Count() == 1) &&
                              (c.GetParameters()[0].ParameterType == typeof(TBusinessLogic)));
										   
    if (constructor == null)
    {
        throw new SomeException();
    }
    TPresenter presenter = (TPresenter)constructor.Invoke(
        new object[]{ businessLogic });
