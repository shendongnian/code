		public IHttpController Create(HttpRequestMessage request,
										HttpControllerDescriptor controllerDescriptor,
										Type controllerType)
		{
			if (ControllersHelper.IsUmbracoController(controllerType))
			{
				return Activator.CreateInstance(controllerType) as IHttpController;
			}
			var controller = (IHttpController)_container.Kernel.Resolve(controllerType);
			request.RegisterForDispose(new Release(() => _container.Kernel.ReleaseComponent(controller)));
			return controller;
		}
