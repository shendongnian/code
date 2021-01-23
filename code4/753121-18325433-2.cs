    public class UnityActionFilterProvider 
        : System.Web.Http.Filters.ActionDescriptorFilterProvider, 
          System.Web.Http.Filters.IFilterProvider
    {
        private readonly IUnityContainer container;
        public UnityActionFilterProvider(IUnityContainer container)
        {
            this.container = container;
        }
        public new IEnumerable<FilterInfo> GetFilters(HttpConfiguration configuration, 
            HttpActionDescriptor actionDescriptor)
        {
            foreach (IActionFilter actionFilter in container.ResolveAll<IActionFilter>())
            {
                // TODO: Determine correct FilterScope
                yield return new FilterInfo(actionFilter, FilterScope.Global);
            }
        }
    }
