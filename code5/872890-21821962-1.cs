    public ExampleController 
    {
        public async Task<ActionResult> Index() 
        {
            using(var serviceClient = ServiceFactory.GetServiceClient())
            using(Security.Impersonation.Impersonate())
            {
                var data = await serviceClient.GetUsernameAsync();
                return View(data);
            }
        }
    }
