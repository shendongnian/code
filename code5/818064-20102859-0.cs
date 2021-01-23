    public static class ContainerExtensions
    {
        public static Container Register(this Container container, 
            object instance, Type asType)
        {
            var mi = container.GetType()
                .GetMethods()
                .First(x => x.Name == "Register" 
                         && x.GetParameters().Length == 1 
                         && x.ReturnType == typeof(void))
                .MakeGenericMethod(asType);
            mi.Invoke(container, new[] { instance });
            return container;
        }
    }
 
