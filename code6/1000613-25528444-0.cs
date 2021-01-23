    public void Execute(AppContext context)
    {
        using (var s = CastleContainer.Container.BeginScope())
        {
            Thread.SetData(Thread.GetNamedDataSlot("context"), context);
            var logic = CastleContainer.Container.Resolve<ICustomerLogic>();
            Thread.SetData(Thread.GetNamedDataSlot("context"), null);
            // begin invocation
        }
    } 
