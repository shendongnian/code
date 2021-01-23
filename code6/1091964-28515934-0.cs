	using Microsoft.Practices.Unity;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	namespace UnityExperiment
	{
		class Program
		{
			static void Main(string[] args)
			{
				// Begin composition root
				var container = new UnityContainer();
				container.AddNewExtension<JobContainerExtension>();
				container.RegisterType<IService1, Service1>(new InjectionConstructor(
					new ResolvedArrayParameter<IJob>(container.ResolveAll<IJob>().ToArray())));
				container.RegisterType<IService2, Service2>(new InjectionConstructor(
					new ResolvedArrayParameter<IJob>(container.ResolveAll<IJob>().ToArray())));
				// End composition root
				var service1 = container.Resolve<IService1>();
				var service2 = container.Resolve<IService2>();
			}
		}
		public class JobContainerExtension : UnityContainerExtension
		{
			protected override void Initialize()
			{
				var interfaceType = typeof(IJob);
				var implementationTypes = AppDomain.CurrentDomain.GetAssemblies()
								.Where(x => x.FullName.StartsWith("UnityExperiment"))
								.SelectMany(x => x.GetTypes())
								.Where(x => x.IsClass && interfaceType.IsAssignableFrom(x));
				foreach (Type implementationType in implementationTypes)
				{
					// IMPORTANT: Give each instance a name, or else Unity won't be able
					// to resolve the collection.
					this.Container.RegisterType(interfaceType, implementationType, 
                        implementationType.Name, new ContainerControlledLifetimeManager());
				}
			}
		}
		public interface IJob
		{
		}
		public class Job1 : IJob
		{
		}
		public class Job2 : IJob
		{
		}
		public class Job3 : IJob
		{
		}
		public interface IService1
		{
		}
		public class Service1 : IService1
		{
			private readonly IJob[] jobs;
			public Service1(IJob[] jobs)
			{
				this.jobs = jobs;
			}
		}
		public interface IService2
		{
		}
		public class Service2 : IService2
		{
			private readonly IEnumerable<IJob> jobs;
			public Service2(IEnumerable<IJob> jobs)
			{
				this.jobs = jobs;
			}
		}
	}
