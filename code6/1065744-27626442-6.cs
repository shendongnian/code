    app.UseErrorHandler(errorApp =>
            {
                // add mvc services
                errorApp.UseServices(services => services.AddMvc());
                // create a router
                var builder = new RouteBuilder();
                builder.Routes.Add(AttributeRouting.CreateAttributeMegaRoute(
                    builder.DefaultHandler,
                    errorApp.ApplicationServices));
                var router = builder.Build();
                errorApp.Run(async context =>
                {
                    // create a route
                    var routeData = new RouteData() { Values = new Dictionary<string, object>() };
                    routeData.Routers.Add(router);
                    // if we want to use a controller view : eg Home
                    // routeData.Values.Add("controller", "Home");
                    // create an action descriptor
                    var descriptor = new ActionDescriptor() { Name = "Error" };
                    
                    // create an action context with the http context, route and action descritor
                    var ac = new ActionContext(context, routeData, descriptor);
                    // get services
                    var services = context.RequestServices;
                    // set the action context in the context accessor
                    var accessor = services.GetRequiredService<IContextAccessor<ActionContext>>();
                    accessor.SetValue(ac);
                    
                    // create a view data dictionary to pass data to the view
                    var viewData = new ViewDataDictionary<Exception>(new DataAnnotationsModelMetadataProvider());
                    
                    // get the error and set it as view's model 
                    var error = context.GetFeature<IErrorHandlerFeature>();
                    if (error != null)
                        viewData.Model = error.Error;
                    // get the view engine
                    var viewEngine = services.GetRequiredService<ICompositeViewEngine>();
                    
                    // create a view result with the view data dictionary and the view engine for the shared Error view
                    ViewResult result = new ViewResult()
                    {
                        ViewData = viewData,
                        ViewEngine = viewEngine,
                        ViewName = "Error"
                    };
                    
                    // render the view
                    await result.ExecuteResultAsync(ac);
                });
            });
