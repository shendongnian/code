	public static Assembly LoadRemoteAssembly(string filename)
	{
		byte[] asmdata = System.IO.File.ReadAllBytes(filename);
		return Assembly.Load(asmdata);
	}
