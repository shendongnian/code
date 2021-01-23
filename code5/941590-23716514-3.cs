    public class SomeFilterProvider : IFilterProvider
    {
        public IEnumerable<FilterInfo> GetFilters(HttpConfiguration configuration, HttpActionDescriptor actionDescriptor)
        {
            if (someReasonToProtect)
            {
                yield return SuperSecrecyFilter();
            }
        }
    }
