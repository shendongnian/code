        protected new IMvxIoCProvider Ioc { get; private set; }
        protected override void ClearAll()
        {
            // fake set up of the IoC
            MvxSingleton.ClearAllSingletons();
            var iocOptions = new MvxIocOptions {
                PropertyInjectorOptions = MvxPropertyInjectorOptions.All
            };
            Ioc = MvxSimpleIoCContainer.Initialize(iocOptions);
            Ioc.RegisterSingleton(Ioc);
            Ioc.RegisterSingleton<IMvxTrace>(new TestTrace());
            MvxSingletonCache.Initialize();
            Ioc.RegisterSingleton<IMvxSettings>(new MvxSettings());
            MvxTrace.Initialize();
            AdditionalSetup();
        }
