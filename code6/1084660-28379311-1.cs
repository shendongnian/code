    [ModelBinderType]
    public class MyCustomModelBinder<T> : DefaultModelBinder where T : class
    {
        [NotNull]
        protected override object CreateModel([NotNull] ControllerContext controllerContext, [NotNull] ModelBindingContext bindingContext, [NotNull] Type modelType)
        {
            var item = DependencyResolver.Current.GetService<T>();
            if (item != null)
            {
                return item;
            }
            throw new ArgumentException(string.Format("model type {0} is not registered", modelType.Name));
        }
    }
