    using Castle.Core;
    using Castle.MicroKernel;
    using Castle.MicroKernel.ComponentActivator;
    using Castle.MicroKernel.Context;
    using Castle.MicroKernel.Facilities;
    using Castle.MicroKernel.Registration;
    using Castle.Windsor;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks; 
    namespace ComponentCreater
    {
    public interface IWatchDogService
    {
        Type WatchingType { get; set; }
    }
    public class WatchDogService : IWatchDogService
    {
        public Type WatchingType { get; set; }
    }
    
    
    public class WatchedClassViaConstructor
    {
        private readonly IWatchDogService watchDogService;
        public WatchedClassViaConstructor(IWatchDogService watchDogService)
        {
            this.watchDogService = watchDogService;
        }
        public void Print()
        {
            Console.WriteLine(this.watchDogService.WatchingType.Name);
        }
    }
    public class WatchDogFacility : AbstractFacility
    {
        protected override void Init()
        {
            this.Kernel.ComponentModelCreated += Kernel_ComponentModelCreated;
        }
        private void Kernel_ComponentModelCreated(ComponentModel model)
        {
            model.CustomComponentActivator = typeof(WatchedComponentActivator);   
        }
    }
    
    public class WatchedComponentActivator : DefaultComponentActivator
    {
        public WatchedComponentActivator(ComponentModel model, IKernel kernel, ComponentInstanceDelegate onCreation, ComponentInstanceDelegate onDestruction)
            : base(model, kernel, onCreation, onDestruction)
        {
        }
        protected override object CreateInstance(CreationContext context, ConstructorCandidate constructor, object[] arguments)
        {
            object component = base.CreateInstance(context, constructor, arguments);
            if (arguments != null)
            {
                IWatchDogService watchDogService = arguments.FirstOrDefault(arg => arg is IWatchDogService) as IWatchDogService;
                if (watchDogService != null)
                {
                    watchDogService.WatchingType = component.GetType();
                }
            }
            return component;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            IWindsorContainer container = new WindsorContainer();
            container.AddFacility<WatchDogFacility>();
            
            container.Register(
                Component.For<IWatchDogService>()
                    .ImplementedBy<WatchDogService>()
                    .LifestyleTransient(),
                Component.For<WatchedClassViaConstructor>()
            );
            WatchedClassViaConstructor obj = container.Resolve<WatchedClassViaConstructor>();
            obj.Print();
            Console.ReadLine();
        }
    }
