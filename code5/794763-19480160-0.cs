	static void Main(string[] args)
	{
		string programFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
		string passArguments = string.Join(" ", args.Select(WrapArgument));
		Process.Start(new ProcessStartInfo(Path.Combine(programFolder, "VidCoderCLI.exe"))
		{
			Arguments = passArguments,
			WindowStyle = ProcessWindowStyle.Hidden
		});
	}
	private static string WrapArgument(string arg)
	{
		if (arg.EndsWith(@"\"))
		{
			return "\"" + arg + "\\\"";
		}
		return "\"" + arg + "\"";
	}
