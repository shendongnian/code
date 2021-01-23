    namespace ComponentCreater2
    {
    using Castle.Core;
    using Castle.MicroKernel;
    using Castle.MicroKernel.ComponentActivator;
    using Castle.MicroKernel.Context;
    using Castle.MicroKernel.Facilities;
    using Castle.MicroKernel.ModelBuilder;
    using Castle.MicroKernel.Registration;
    using Castle.Windsor;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public interface IWatchDogService
    {
        Type WatchingType { get; set; }
    }
    public class WatchDogService : IWatchDogService
    {
        public Type WatchingType { get; set; }
    }
    public interface IIsWatched
    {
        IWatchDogService WatchDogService { get; set; }
    }
    public abstract class WatchedClass : IIsWatched
    {
        public IWatchDogService WatchDogService { get; set; }
    }
    public class WatchedClassViaInheritance : WatchedClass
    {
        public void Print()
        {
            Console.WriteLine(this.WatchDogService.WatchingType.Name);
        }
    }
    public class WatchDogFacility : AbstractFacility
    {
        protected override void Init()
        {
            this.Kernel.ComponentModelCreated += Kernel_ComponentModelCreated;
            this.Kernel.ComponentModelBuilder.AddContributor(new RequireWatchDogService());
        }
        private void Kernel_ComponentModelCreated(ComponentModel model)
        {
            if (typeof(IIsWatched).IsAssignableFrom(model.Implementation))
            {
                model.CustomComponentActivator = typeof(WatchedComponentActivator);
            }
        }
    }
    public class WatchedComponentActivator : DefaultComponentActivator
    {
        public WatchedComponentActivator(ComponentModel model, IKernel kernel, ComponentInstanceDelegate onCreation, ComponentInstanceDelegate onDestruction)
            : base(model, kernel, onCreation, onDestruction)
        {
        }
        protected override void SetUpProperties(object instance, CreationContext context)
        {
            base.SetUpProperties(instance, context);
            IIsWatched watched = instance as IIsWatched;
            if (watched != null)
            {
                watched.WatchDogService.WatchingType = instance.GetType();
            }
        }
    }
    public class RequireWatchDogService : IContributeComponentModelConstruction
    {
       public void ProcessModel(IKernel kernel, ComponentModel model) 
       { 
           model.Properties.Where(prop => prop.Dependency.TargetType == typeof(IWatchDogService))
               .All(prop => prop.Dependency.IsOptional = false); 
       } 
    }
    
    class Program2
    {
        static void Main(string[] args)
        {
            IWindsorContainer container = new WindsorContainer();
            container.AddFacility<WatchDogFacility>();
            container.Register(
                Component.For<IWatchDogService>()
                    .ImplementedBy<WatchDogService>()
                    .LifestyleTransient(),
                Component.For<WatchedClassViaInheritance>()
            );
            WatchedClassViaInheritance obj = container.Resolve<WatchedClassViaInheritance>();
            obj.Print();
            Console.ReadLine();
        }
    }
}
