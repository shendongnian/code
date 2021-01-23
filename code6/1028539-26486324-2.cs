	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Reflection;
	using Nancy.Bootstrapper;
	using Nancy.TinyIoc;
	using Nancy;
	using Nancy.Diagnostics;
	using Spring.Context;
	using Spring.Context.Support;
	namespace FORREST.WebService.General.Bootstrap
	{
		/// <summary>
		/// Class enabling the use of Spring injections in modules.
		/// </summary>
		public abstract class HybridNancyBootstrapperBase : NancyBootstrapperWithRequestContainerBase<DualContainer>
		{
			/// <summary>
			/// Default assemblies that are ignored for autoregister
			/// </summary>
			public static IEnumerable<Func<Assembly, bool>> DefaultAutoRegisterIgnoredAssemblies = new Func<Assembly, bool>[]
				{
					asm => asm.FullName.StartsWith("Microsoft.", StringComparison.InvariantCulture),
					asm => asm.FullName.StartsWith("System.", StringComparison.InvariantCulture),
					asm => asm.FullName.StartsWith("System,", StringComparison.InvariantCulture),
					asm => asm.FullName.StartsWith("CR_ExtUnitTest", StringComparison.InvariantCulture),
					asm => asm.FullName.StartsWith("mscorlib,", StringComparison.InvariantCulture),
					asm => asm.FullName.StartsWith("CR_VSTest", StringComparison.InvariantCulture),
					asm => asm.FullName.StartsWith("DevExpress.CodeRush", StringComparison.InvariantCulture),
					asm => asm.FullName.StartsWith("IronPython", StringComparison.InvariantCulture),
					asm => asm.FullName.StartsWith("IronRuby", StringComparison.InvariantCulture),
					asm => asm.FullName.StartsWith("xunit", StringComparison.InvariantCulture),
					asm => asm.FullName.StartsWith("Nancy.Testing", StringComparison.InvariantCulture),
					asm => asm.FullName.StartsWith("MonoDevelop.NUnit", StringComparison.InvariantCulture),
					asm => asm.FullName.StartsWith("SMDiagnostics", StringComparison.InvariantCulture),
					asm => asm.FullName.StartsWith("CppCodeProvider", StringComparison.InvariantCulture),
					asm => asm.FullName.StartsWith("WebDev.WebHost40", StringComparison.InvariantCulture),
				};
			/// <summary>
			/// Gets the assemblies to ignore when autoregistering the application container
			/// Return true from the delegate to ignore that particular assembly, returning true
			/// does not mean the assembly *will* be included, a false from another delegate will
			/// take precedence.
			/// </summary>
			protected virtual IEnumerable<Func<Assembly, bool>> AutoRegisterIgnoredAssemblies
			{
				get { return DefaultAutoRegisterIgnoredAssemblies; }
			}
			/// <summary>
			/// Configures the container using AutoRegister followed by registration
			/// of default INancyModuleCatalog and IRouteResolver.
			/// </summary>
			/// <param name="container">Container instance</param>
			protected override void ConfigureApplicationContainer(DualContainer container)
			{
				AutoRegister(container, this.AutoRegisterIgnoredAssemblies);
			}
			/// <summary>
			/// Resolve INancyEngine
			/// </summary>
			/// <returns>INancyEngine implementation</returns>
			protected override sealed INancyEngine GetEngineInternal()
			{
				return this.ApplicationContainer.TinyIoCContainer.Resolve<INancyEngine>();
			}
			/// <summary>
			/// Create a default, unconfigured, container
			/// </summary>
			/// <returns>Container instance</returns>
			protected override DualContainer GetApplicationContainer()
			{
				return new DualContainer
				{
					ApplicationContext = ContextRegistry.GetContext(),
					TinyIoCContainer = new TinyIoCContainer()
				};              
			}
			/// <summary>
			/// Register the bootstrapper's implemented types into the container.
			/// This is necessary so a user can pass in a populated container but not have
			/// to take the responsibility of registering things like INancyModuleCatalog manually.
			/// </summary>
			/// <param name="applicationContainer">Application container to register into</param>
			protected override sealed void RegisterBootstrapperTypes(DualContainer applicationContainer)
			{
				applicationContainer.TinyIoCContainer.Register<INancyModuleCatalog>(this);
			}
			/// <summary>
			/// Register the default implementations of internally used types into the container as singletons
			/// </summary>
			/// <param name="container">Container to register into</param>
			/// <param name="typeRegistrations">Type registrations to register</param>
			protected override sealed void RegisterTypes(DualContainer container, IEnumerable<TypeRegistration> typeRegistrations)
			{
				foreach (var typeRegistration in typeRegistrations)
				{
					switch (typeRegistration.Lifetime)
					{
						case Lifetime.Transient:
							container.TinyIoCContainer.Register(typeRegistration.RegistrationType
								, typeRegistration.ImplementationType).AsMultiInstance();
							break;
						case Lifetime.Singleton:
							container.TinyIoCContainer.Register(typeRegistration.RegistrationType
								, typeRegistration.ImplementationType).AsSingleton();
							break;
						case Lifetime.PerRequest:
							throw new InvalidOperationException("Unable to directly register a per request lifetime.");
						default:
							throw new ArgumentOutOfRangeException();
					}
				}
			}
			/// <summary>
			/// Register the various collections into the container as singletons to later be resolved
			/// by IEnumerable{Type} constructor dependencies.
			/// </summary>
			/// <param name="container">Container to register into</param>
			/// <param name="collectionTypeRegistrations">Collection type registrations to register</param>
			protected override sealed void RegisterCollectionTypes(DualContainer container, IEnumerable<CollectionTypeRegistration> collectionTypeRegistrations)
			{
				foreach (var collectionTypeRegistration in collectionTypeRegistrations)
				{
					switch (collectionTypeRegistration.Lifetime)
					{
						case Lifetime.Transient:
							container.TinyIoCContainer.RegisterMultiple(collectionTypeRegistration.RegistrationType
								, collectionTypeRegistration.ImplementationTypes).AsMultiInstance();
							break;
						case Lifetime.Singleton:
							container.TinyIoCContainer.RegisterMultiple(collectionTypeRegistration.RegistrationType
								, collectionTypeRegistration.ImplementationTypes).AsSingleton();
							break;
						case Lifetime.PerRequest:
							throw new InvalidOperationException("Unable to directly register a per request lifetime.");
						default:
							throw new ArgumentOutOfRangeException();
					}
				}
			}
			/// <summary>
			/// Register the given module types into the container
			/// </summary>
			/// <param name="container">Container to register into</param>
			/// <param name="moduleRegistrationTypes">NancyModule types</param>
			protected override sealed void RegisterRequestContainerModules(DualContainer container, IEnumerable<ModuleRegistration> moduleRegistrationTypes)
			{
				foreach (var moduleRegistrationType in moduleRegistrationTypes)
				{
					container.TinyIoCContainer.Register(
						typeof(INancyModule),
						moduleRegistrationType.ModuleType,
						moduleRegistrationType.ModuleType.FullName).
						AsSingleton();
					(container.ApplicationContext as IConfigurableApplicationContext).ObjectFactory.
						RegisterResolvableDependency(moduleRegistrationType.ModuleType, 
						container.TinyIoCContainer.Resolve(moduleRegistrationType.ModuleType));
				}
			}
			/// <summary>
			/// Register the given instances into the container
			/// </summary>
			/// <param name="container">Container to register into</param>
			/// <param name="instanceRegistrations">Instance registration types</param>
			protected override void RegisterInstances(DualContainer container, IEnumerable<InstanceRegistration> instanceRegistrations)
			{
				foreach (var instanceRegistration in instanceRegistrations)
				{
					container.TinyIoCContainer.Register(
						instanceRegistration.RegistrationType,
						instanceRegistration.Implementation);
					//Cast zodat het programmatisch kan worden gedaan
					(container.ApplicationContext as IConfigurableApplicationContext).ObjectFactory.RegisterResolvableDependency(
						instanceRegistration.RegistrationType,
						instanceRegistration.Implementation);            
				}
			}
			/// <summary>
			/// Creates a per request child/nested container
			/// </summary>
			/// <returns>Request container instance</returns>
			protected override sealed DualContainer CreateRequestContainer()
			{
				return this.ApplicationContainer.GetChildContainer();
			}
			/// <summary>
			/// Gets the diagnostics for initialisation
			/// </summary>
			/// <returns>IDiagnostics implementation</returns>
			protected override IDiagnostics GetDiagnostics()
			{
				return this.ApplicationContainer.TinyIoCContainer.Resolve<IDiagnostics>();
			}
			/// <summary>
			/// Gets all registered startup tasks
			/// </summary>
			/// <returns>An <see cref="IEnumerable{T}"/> instance containing <see cref="IApplicationStartup"/> instances. </returns>
			protected override IEnumerable<IApplicationStartup> GetApplicationStartupTasks()
			{
				return this.ApplicationContainer.TinyIoCContainer.ResolveAll<IApplicationStartup>(false);
			}
			/// <summary>
			/// Gets all registered request startup tasks
			/// </summary>
			/// <returns>An <see cref="IEnumerable{T}"/> instance containing <see cref="IRequestStartup"/> instances.</returns>
			protected override IEnumerable<IRequestStartup> RegisterAndGetRequestStartupTasks(DualContainer container, Type[] requestStartupTypes)
			{
				container.TinyIoCContainer.RegisterMultiple(typeof(IRequestStartup), requestStartupTypes);
				return container.TinyIoCContainer.ResolveAll<IRequestStartup>(false);
			}
			/// <summary>
			/// Gets all registered application registration tasks
			/// </summary>
			/// <returns>An <see cref="IEnumerable{T}"/> instance containing <see cref="IRegistrations"/> instances.</returns>
			protected override IEnumerable<IRegistrations> GetRegistrationTasks()
			{
				return this.ApplicationContainer.TinyIoCContainer.ResolveAll<IRegistrations>(false);
			}
			/// <summary>
			/// Retrieve all module instances from the container
			/// </summary>
			/// <param name="container">Container to use</param>
			/// <returns>Collection of NancyModule instances</returns>
			protected override sealed IEnumerable<INancyModule> GetAllModules(DualContainer container)
			{
				var nancyModules = container.TinyIoCContainer.ResolveAll<INancyModule>(false);
				return nancyModules;
			}
			/// <summary>
			/// Retreive a specific module instance from the container
			/// </summary>
			/// <param name="container">Container to use</param>
			/// <param name="moduleType">Type of the module</param>
			/// <returns>NancyModule instance</returns>
			protected override sealed INancyModule GetModule(DualContainer container, Type moduleType)
			{
				INancyModule module;
				try
				{
					module = (INancyModule) container.ApplicationContext.GetObject(moduleType.Name, moduleType);
				}
					//Niet geregistreerd in Spring, gebruik TinyIoCContainer om op te halen
				catch (Spring.Objects.Factory.NoSuchObjectDefinitionException)
				{
					System.Diagnostics.Debug.WriteLine("Laad " + moduleType.Name + " uit TinyIoC in plaats van Spring");
					container.TinyIoCContainer.Register(typeof(INancyModule), moduleType);
					module = container.TinyIoCContainer.Resolve<INancyModule>();
				}            
				return module;
			}
			/// <summary>
			/// Executes auto registation with the given container.
			/// </summary>
			/// <param name="container">Container instance</param>
			private static void AutoRegister(DualContainer container, IEnumerable<Func<Assembly, bool>> ignoredAssemblies)
			{
				var assembly = typeof(NancyEngine).Assembly;
				container.TinyIoCContainer.AutoRegister(AppDomain.CurrentDomain.GetAssemblies()
					.Where(a => !ignoredAssemblies.Any(ia => ia(a)))
					, DuplicateImplementationActions.RegisterMultiple, t => t.Assembly != assembly);
			}        
		}
	}
