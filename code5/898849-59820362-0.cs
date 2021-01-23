csharp
/// <summary>
/// The main method.
/// </summary>
/// <param name="args">Some arguments.</param>
public static void Main(string[] args)
{
	var pathToExe = Process.GetCurrentProcess().MainModule.FileName;
	var pathToContentRoot = Path.GetDirectoryName(pathToExe);
	var host = WebHost.CreateDefaultBuilder(args)
		.UseContentRoot(pathToContentRoot)
		.UseStartup<Startup>()
		.UseUrls("http://*:8084")
		.Build();
	host.RunAsService();
}
should run the service as worker template with a specified port.
