    var kernel = new StandardKernel();
    kernel.Bind<Presenter1>().ToSelf();
	kernel.Bind<Presenter2>().ToSelf();
	kernel.Bind<Presenter3>().ToSelf();
	kernel.Bind<IPresenter>().To<CompositePresenter>()
		.WithConstructorArgument("presenters", 
			new IPresenter[] { 
				kernel.Get<Presenter1>(), 
				kernel.Get<Presenter2>(),
				kernel.Get<Presenter3>() 
			});
    // When SomeConsumer is injected into a constructor, its IPresenter 
    // dependency will be wired as shown with the new keyword example above.
	
