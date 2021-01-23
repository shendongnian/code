	/// <summary>
	/// Castle windsor installer for controller components.
	/// </summary>
	public class ControllersInstaller : IWindsorInstaller
	{
		/// <summary>
		/// Performs the installation in the <see cref="T:Castle.Windsor.IWindsorContainer"/>.
		/// </summary>
		/// <param name="container">The container.</param>
		/// <param name="store">The configuration store.</param>
		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			container.Register(
				Classes.FromThisAssembly()
					.BasedOn<IController>()
					.LifestyleTransient()
			);
		}
	}
