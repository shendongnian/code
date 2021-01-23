	class Program
	{
		private static void RegisterAsRun()
		{
			string exePath = new Uri(Assembly.GetEntryAssembly().CodeBase).LocalPath;			
			Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", "TestApp", exePath, RegistryValueKind.String);
		}
		static void Main(string[] args)
		{
			RegisterAsRun();
			Console.WriteLine("Hello!");
			Console.ReadLine();
		}
	}
