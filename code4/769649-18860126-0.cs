	public static class IoC
	{
		public static IWindsorContainer Container { get;set; }
	}
	var container = new WindsorContainer().Install(
		FromAssembly.This()
	);
	IoC.Container = container;
