    public override void Configure(Funq.Container container)
    {
        //Set MVC to use the same Funq IOC as ServiceStack
        ControllerBuilder.Current.SetControllerFactory(new FunqControllerFactory(container));
    }
