    public class NinjectDependencyResolver : IDependencyResolver
        {
        //Bunch of initialization and methods 
        Check out this : [Using ninject in MVC][2].
        //Binding piece (Very important)
         private void AddBindings()
                {
                    //Context DB Binding
                    kernel.Bind<IModelDBContext>().To<ModelDBContext>();
                    //Other binding
                }
        }
