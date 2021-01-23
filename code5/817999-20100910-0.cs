     public static IViewModelProduct CreateViewModel(IProduct passedProductModel)
        {
            var viewModelContainer = new UnityContainer();
            viewModelContainer.RegisterType<IViewModelProduct, ViewModelProduct>(new InjectionConstructor(passedProductModel));
            var newViewModelObject = viewModelContainer.Resolve<IViewModelProduct>();
            return newViewModelObject;
        }
