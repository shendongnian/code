    public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();
           
            if(Config.Config.type == ControlType.Type1)
            {
                Mvx.RegisterType<IControlService, Type1>();
            }
            else if (Config.Config.type == ControlType.Type2)
            {
                Mvx.RegisterType<IControlService, Type2>();
            }
            
            RegisterAppStart<ViewModels.FirstViewModel>();
        }
