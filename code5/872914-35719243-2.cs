    public class OrderedFilterProvider : IFilterProvider
    {
        public IEnumerable<FilterInfo> GetFilters(HttpConfiguration configuration, HttpActionDescriptor actionDescriptor)
        {
            // controller-specific
            var controllerSpecificFilters = OrderFilters(actionDescriptor.ControllerDescriptor.GetFilters(), FilterScope.Controller);
            // action-specific
            var actionSpecificFilters = OrderFilters(actionDescriptor.GetFilters(), FilterScope.Action);
            return controllerSpecificFilters.Concat(actionSpecificFilters);
        }
        private IEnumerable<FilterInfo> OrderFilters(IEnumerable<IFilter> filters, FilterScope scope)
        {
            // get all filter that dont implement IOrderedFilter and give them order number of 0
            var notOrderableFilter = filters.Where(f => !(f is IOrderedFilter))
                .Select(instance => new KeyValuePair<int, FilterInfo>(0, new FilterInfo(instance, scope)));
            // get all filter that implement IOrderFilter and give them order number from the instance
            var orderableFilter = filters.OfType<IOrderedFilter>().OrderBy(filter => filter.Order)
                .Select(instance => new KeyValuePair<int, FilterInfo>(instance.Order, new FilterInfo(instance, scope)));
            // concat lists => order => return
            return notOrderableFilter.Concat(orderableFilter).OrderBy(x => x.Key).Select(y => y.Value);
        }
    }
