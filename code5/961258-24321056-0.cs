    namespace DependencyResolver
    {
       public class MyModule : NinjectModule
       {
           public override void Load()
           {
               Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
            }
    }
