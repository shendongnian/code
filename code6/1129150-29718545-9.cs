    public static void Register(IKernel kernel)
	{
		kernel.Bind<IDataAccessClass>().To<DataAccessClass>();
		kernel.Bind<ProductLogic>().ToSelf();
	}
