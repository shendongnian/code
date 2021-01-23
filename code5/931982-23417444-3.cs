    bool useA = true, useB = false;
    builder.Register(c =>
    {
        IFoo result = c.Resolve<Impl>();
        if (useA)
            result = c.Resolve<DecoratorA>(TypedParameter.From(result));
        if (useB)
            result = c.Resolve<DecoratorB>(TypedParameter.From(result));
        return result;
    }).As<IFoo>();
