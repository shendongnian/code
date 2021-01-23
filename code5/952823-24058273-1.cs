    [Fact]
	public void ShouldBeAbleToLocateTheViewForAViewModel()
	{
		var container = StructureMapBootstrapper.Instance.Container;
		var ihas = container.WhatDoIHave();
		Locator.Current = new ApplicationDependencyResolver(container);
		Locator.CurrentMutable.InitializeSplat();
		Locator.CurrentMutable.InitializeReactiveUI();
		var vm = new SplashScreenViewModel();
		var viewLocator = Locator.Current.GetService<IViewLocator>();
		var view = viewLocator.ResolveView(vm);
		view.Should().NotBeNull().And.BeOfType<SplashScreenView>();
	}
