	public static class NinjectWebCommon 
	{
		...
		private static IKernel kernel;
		public static IKernel CreateKernel()
		{
			if(kernel != null)
				return kernel;
				
			kernel = new StandardKernel();
			kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
			kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
			RegisterServices(kernel);
			return kernel;
		}
		...
	}
	public partial class Default : Page
	{
		[Inject]
		public ICalculate _calculate { get; set; }
		protected void Page_Load(object sender, EventArgs e)
		{
			NinjectWebCommon.CreateKernel().Inject(MyServerControl1);
		}
	}
