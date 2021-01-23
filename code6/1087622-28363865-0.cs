	public partial class App : Application
	{
		protected override void OnStartup(StartupEventArgs e)
		{
			object parameter = new object();
    		ServiceLocator.Default.
				RegisterInstance<INthChildService>(new NthChildService(parameter));
		}
	}
