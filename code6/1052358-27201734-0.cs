    var builder = new ContainerBuilder();
    // Register all instances of IDiscountCalculator
    builder.RegisterAssemblyTypes(this.GetType().Assembly)
           .Where(t => typeof(IDiscountCalculator).IsAssignableFrom(t));
    builder.Register<DiscountStrategy>().As<IDiscountStrategy>();
    var container = builder.Build();
    var strategy = container.Resolve<IDiscountStrategy>();
    Console.WriteLine(strategy.GetDiscount("Regular", 10)); // 0
    Console.WriteLine(strategy.GetDiscount("Normal", 10)); // 1
    Console.WriteLine(strategy.GetDiscount("Special", 10)); // 5
