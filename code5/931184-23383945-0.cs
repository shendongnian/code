    public IHttpController Create(HttpRequestMessage request, 
        HttpControllerDescriptor descriptor, Type type)
    {
        var wrapper = new ModelStateDictionaryWrapper();
        var controller = new CategoryController(new CategoryService(wrapper));
	
        wrapper.ModelState = controller.ModelState;
        return controller;
    }
