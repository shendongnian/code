    this.Bind(x => x
        .FromThisAssembly()
        .SelectAllClasses()
        .InheritedFrom(typeof(BusinessObject<>))
        .BindWith<BusinessObjectBindingGenerator>());
    public class BusinessObjectBindingGenerator : IBindingGenerator
    {
        public IEnumerable<IBindingWhenInNamedWithOrOnSyntax<object>> CreateBindings(Type type, IBindingRoot bindingRoot)
        {
            yield return bindingRoot
                .Bind(type)
                .ToMethod(ctx => CreateBusinessObject(type));
        }
        private static object CreateBusinessObject(Type type)
        {
            return typeof(BusinessObject<>)
                .MakeGenericType(type)
                .GetMethod("GetInstance")
                .Invoke(null, new object[0]);
        }
    }
