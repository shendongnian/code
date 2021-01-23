    // option a (recommended)
    var kernel = new StandardKernel(new Bindings());
    var bar = kernel.Get<IDependency>();
    Assert.IsFalse(bar.DependencyIsNull());
    // option b (not recommended.. but do-able)
    var kernel = new StandardKernel(new Bindings());
    var bar = new Depender();
    kernel.Inject(bar); // injects after the fact
    Assert.IsFalse(bar.DependencyIsNull());
