    var container = new SimpleInjector.Container();
    var services = GlobalConfiguration.Configuration.Services;
    var controllerTypes = services.GetHttpControllerTypeResolver()
        .GetControllerTypes(services.GetAssembliesResolver());
    Type decoratorType = typeof(MyHttpControllerDecorator<>);
    foreach (var controllerType in controllerTypes)
    {
        if (controllerType.Namespace == "WebApiTest.Controllers")
        {
            Type decoratedType = decoratorType.MakeGenericType(controllerType);
            container.Register(decoratedType, () => 
                DecoratorBuilder(container.GetInstance(controllerType) as dynamic));
        }
        else
        {
            container.Register(controllerType);
        }
    }
