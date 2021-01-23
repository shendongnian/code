	var container = new UnityContainer();
	container.RegisterType<ICanvas, Canvas>();
	if (CheckIfItIsDx11)
	{
		container.RegisterType<IRenderer, Dx11Renderer>();
	}
	else
	{
		container.RegisterType<IRenderer, GlRenderer>();
	}
