    public void Resolve_GetByIdHandler_Succeeds()
    {
        var container = new Castle.Windsor.WindsorContainer();
        container.Register(Component
            .For(typeof(IQueryHandler<,>))
            .ImplementedBy(typeof(GetByIdHandler<>)));
        var x = container.Resolve<IQueryHandler<GetById<Event>, Event>>();
    }
