    Assembly asm = Assembly.GetExecutingAssembly();
    container.RegisterManyForOpenGeneric(typeof(IView<>), asm);
    container.RegisterManyForOpenGeneric(typeof(IViewModel<>), asm);
    container.RegisterOpenGeneric(typeof(IViewProvider<,>), 
        typeof(ViewProvider<,>), Lifestyle.Singleton);
    container.RegisterOpenGeneric(typeof(IModelProvider<>), 
        typeof(ModelProvider<>), Lifestyle.Singleton);
        
    var controllers =
        from type in asm.GetTypes()
        where type.IsSubClassOf(typeof(Controller))
        where !type.IsAbstract
        select type;
        
    controllers.ToList().ForEach(t => container.Register(t));
    container.Verify();
