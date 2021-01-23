    public SomeClassProjection SomeClass
    {
        get
        {
            // some stuff is done here
            SomeClassState.Value = queryProcessor
                        .Execute(new ExistingProductsQuery { OrderNumber = SelectedOrderNumber });
            return SomeClassState.Value;
        }
    }
