    private static void RegisterWebPagesAndControls(Container container)
    {
        var pageTypes =
            from assembly in BuildManager.GetReferencedAssemblies().Cast<Assembly>()
            where !assembly.IsDynamic
            where !assembly.GlobalAssemblyCache
            from type in assembly.GetExportedTypes()
            where type.IsSubclassOf(typeof(Page)) || type.IsSubclassOf(typeof(UserControl))
            where !type.IsAbstract && !type.IsGenericType
            select type;
        pageTypes.ToList().ForEach(container.Register);
    }
    class ImportAttributePropertySelectionBehavior : IPropertySelectionBehavior
    {
        public bool SelectProperty(Type serviceType, PropertyInfo propertyInfo)
        {
            // Makes use of the System.ComponentModel.Composition assembly
            return (typeof(Page).IsAssignableFrom(serviceType) ||
                typeof(UserControl).IsAssignableFrom(serviceType)) &&
                propertyInfo.GetCustomAttributes<ImportAttribute>().Any();
        }
    }
