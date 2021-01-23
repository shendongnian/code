    public class UnityActionFilterProvider 
        : ActionDescriptorFilterProvider, IFilterProvider
    {
        private readonly IUnityContainer container;
        public UnityActionFilterProvider(IUnityContainer container)
        {
            this.container = container;
        }
        public new IEnumerable<FilterInfo> GetFilters(
            HttpConfiguration configuration, 
            HttpActionDescriptor actionDescriptor)
        {
            var filters = base.GetFilters(configuration, actionDescriptor);
            List<FilterInfo> filterInfoList = new List<FilterInfo>();
            foreach (var filter in filters)
            {
                container.BuildUp(filter.Instance.GetType(), filter.Instance);
            }
            return filters;
        }
    }
