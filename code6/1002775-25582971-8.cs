    public class YourModule : NinjectModule {
        public override void Load() {
            Bind<IExample>().To<Example>().InRequestScope();
            Bind<IService>().To<Service>().InRequestScope();
        }
    }
