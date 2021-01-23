    // However you decide to setup your factory method
    public static void CreateViewModelAndController(
        out ViewModel viewModel, 
        out Controller controller, 
        IUnityContainer unityContainer)
    {
        Model model = unityContainer.Resolve<Model>();
        viewModel = unityContainer.Resolve<ViewModel>(new InjectionConstructor(model));
        controller = unityContainer.Resolve<Controller>(new InjectionConstructor(model));
    }
