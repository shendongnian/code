    using Ninject.Modules;
    using Ninject; 
    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IRepository>().To<MyFirstRepo>();
        }
    }
