	static void Main(string[] args)
	{
		var kernel = new StandardKernel();
		Register(kernel); // register the objects
		var productLogic = kernel.Get<ProductLogic>(); // create instance
	}
