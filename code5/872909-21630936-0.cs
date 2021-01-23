        // Start clean by replacing with filter provider for global configuration.
        // For these globally added filters we need not do any ordering as filters are 
        // executed in the order they are added to the filter collection
        config.Services.Replace(typeof(IFilterProvider), new ConfigurationFilterProvider());
        // Custom action filter provider which does ordering
        config.Services.Add(typeof(IFilterProvider), new OrderedFilterProvider());
       ----------
        public class OrderedFilterProvider : IFilterProvider
        {
            public IEnumerable<FilterInfo> GetFilters(HttpConfiguration configuration, HttpActionDescriptor actionDescriptor)
            {
                // controller-specific
                IEnumerable<FilterInfo> controllerSpecificFilters = OrderFilters(actionDescriptor.ControllerDescriptor.GetFilters(), FilterScope.Controller);
                // action-specific
                IEnumerable<FilterInfo> actionSpecificFilters = OrderFilters(actionDescriptor.GetFilters(), FilterScope.Action);
                return controllerSpecificFilters.Concat(actionSpecificFilters);
            }
            private IEnumerable<FilterInfo> OrderFilters(IEnumerable<IFilter> filters, FilterScope scope)
            {
                return filters.OfType<IOrderedFilter>()
                                .OrderBy(filter => filter.Order)
                                .Select(instance => new FilterInfo(instance, scope));
            }
        }
       ----------
        //NOTE: Here I am creating base attributes which you would need to inherit from.
        public interface IOrderedFilter : IFilter
        {
            int Order { get; set; }
        }
        public class ActionFilterWithOrderAttribute : ActionFilterAttribute, IOrderedFilter
        {
            public int Order { get; set; }
        }
        public class AuthorizationFilterWithOrderAttribute : AuthorizationFilterAttribute, IOrderedFilter
        {
            public int Order { get; set; }
        }
        public class ExceptionFilterWithOrderAttribute : ExceptionFilterAttribute, IOrderedFilter
        {
            public int Order { get; set; }
        }
 
