    /// <summary>
    /// Initializes a new instance of the <see cref="T:System.Object"/> class.
    /// </summary>
    static A()
    {
    	AppDomain.CurrentDomain.AssemblyResolve += (sender, e) =>
    	{
    		var path = Path.Combine(Directory.GetCurrentDirectory(), "bin\\F3BC4DNI.DLL");
    		return Assembly.LoadFile(path);
    	};
    }
