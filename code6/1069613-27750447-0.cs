    Type fooAType = Assembly.LoadFrom(@"path\to\fooA.dll").GetType("FooA");
    Type fooBType = Assembly.LoadFrom(@"path\to\fooB.dll").GetType("FooB");
    container.RegisterWithContext<IFooInterface>(context => {
        if (context.ImplementationType.Name == "ControllerA") 
        {
            return container.GetInstance(fooAType);
        } 
        else if (context.ImplementationType.Name == "ControllerB") 
        {
            return container.GetInstance(fooBType)
        } 
        else 
        {
            return null;
        }
    });
