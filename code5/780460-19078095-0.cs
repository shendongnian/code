    using (DataContext context = provider.CreateDataContext())
    {
        provider.FirstMethod(context, ...);
        provider.SecondMethod(context, ...);
    }
