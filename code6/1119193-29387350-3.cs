    var container3 = new Container();
    container3.Options.AllowOverridingRegistrations = true;
    new ModuleA.Registration().Register(container3);
    new ModuleB.Registration().Register(container3);
    // you can choose which ICommon should be registered.
    container3.Register<ICommon, ModuleA.CommonA>();
    // or collect all implementation of ICommon
    // (of course using Assembly.GetTypes() is better solution)
    container3.RegisterAll<ICommon>(typeof (ModuleA.CommonA), typeof (ModuleB.CommonB));
    container3.Options.AllowOverridingRegistrations = false;
    container3.Verify();
    
    var commonInstance3 = container3.GetInstance<ICommon>();
    var commonInstances3 = container3.GetAllInstances<ICommon>();
