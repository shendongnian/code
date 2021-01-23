    using (_mocks.Record())
    {
        SetupResult.For(averageJoeService.Authenticate(null,
            null)).IgnoreArguments().Return(true); 
    }
