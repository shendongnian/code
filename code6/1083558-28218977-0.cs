    IOrderProcessor GetOrderProcessor(bool isInsideOrder) 
    {
        if (isInsideOrder)
        {
            return DependencyInjector.Inject()
                .ForType<Order>()
                .ImplementedyBy<InsideOrderProcessor>();
        }
        else
        {
            return DependencyInjector.Inject()
                .ForType<Order>()
                .ImplementedBy<OutisdeOrderProcessor>();
        }
    }
