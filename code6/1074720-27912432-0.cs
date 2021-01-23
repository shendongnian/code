	public static void Main()
	{
		var full = Environment.OSVersion.VersionString;
		var joint = Environment.OSVersion.Version.ToString(2);
		var major = Environment.OSVersion.Version.Major;
		var minor = Environment.OSVersion.Version.Minor;
		
		Console.WriteLine("Full: " + full);
		Console.WriteLine("Joint: " + joint);
		Console.WriteLine("Major: " + major);
		Console.WriteLine("Minor: " + minor);
	}
