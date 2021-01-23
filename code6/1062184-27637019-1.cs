    public void GetInstance_GetByIdHandler_Succeeds()
    {
        var container = new SimpleInjector.Container();
        container.RegisterOpenGeneric(
            typeof(IQueryHandler<,>),
            typeof(GetByIdHandler<>));
        var x = container.GetInstance<IQueryHandler<GetById<Event>, Event>>();
    }
