    public class SingletonEqualizer :
        IContributeComponentModelConstruction
    {
        public void ProcessModel(IKernel kernel, 
            ComponentModel model)
        {
            model.LifestyleType = LifestyleType.Singleton;
        }
    }
    /*  ---  */
    
    var container = new WindsorContainer();
    container.Kernel.ComponentModelBuilder
        .AddContributor(new SingletonEqualizer()); // before the intaller is called
    container.Install(new FooInstaller());
