    var container2 = new Container();
    container2.Options.AllowOverridingRegistrations = true;
    new ModuleA.Registration().Register(container2);
    new ModuleB.Registration().Register(container2);
    container2.Options.AllowOverridingRegistrations = false;
    container2.Verify();
    
    var commonInstance2 = container2.GetInstance<ICommon>();
    var commonInstances2 = container2.GetAllInstances<ICommon>();
