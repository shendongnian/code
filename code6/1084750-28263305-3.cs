    public static void BindParameter(this HttpConfiguration config, Type type, Type binderType)
    {
        config.Services.Insert(typeof(ModelBinderProvider), 0, new SimpleModelBinderProvider(type, () => (IModelBinder)config.DependencyResolver.GetService(binderType)));
        config.ParameterBindingRules.Insert(0, type, param => param.BindWithModelBinding());
    }
