      public static class AutofacHelper
    {
        public static T Resolve<T>(this IDependencyResolver container, Parameter[] paramsCtor = null)
        {
            var rawContainer = (AutofacDependencyResolver) DependencyResolver.Current;
            return rawContainer.ApplicationContainer.Resolve<T>((IEnumerable<Parameter>) paramsCtor);
        }
    }
