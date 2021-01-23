    public class App : Cirrious.MvvmCross.ViewModels.MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();
            Globals.Init().Wait();
            if (Globals.HasCredentials())
            {
                RegisterAppStart<ViewModels.DispatchListViewModel>();
            }
            else
            {
                RegisterAppStart<ViewModels.WelcomeViewModel>();
            }
        }
    }
