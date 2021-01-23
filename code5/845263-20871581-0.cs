    // Impl implements IInterface1, IInterface2 and IInterface3.
    var registration =
        Lifestyle.Singleton.CreateRegistration<Impl>(container);
    
    container.AddRegistration(typeof(IInterface1), registration);
    container.AddRegistration(typeof(IInterface2), registration);
    container.AddRegistration(typeof(IInterface3), registration);
    
    var a = container.GetInstance<IInterface1>();
    var b = container.GetInstance<IInterface2>();
    
    // Since Impl is a singleton, both requests return the same instance.
    Assert.AreEqual(a, b);
