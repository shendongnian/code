    using StructureMap;
    using System.Collections.Generic;
    using System.Web.Mvc;
    
    namespace DI06.CustomFilters
    {
        public class StructureMapFilterProvider : FilterAttributeFilterProvider
        {
            private readonly IContainer _container;
            public StructureMapFilterProvider(IContainer container)
            {
                _container = container;
            }
    
            public override IEnumerable<Filter> GetFilters(ControllerContext controllerContext, ActionDescriptor actionDescriptor)
            {
                var filters = base.GetFilters(controllerContext, actionDescriptor);
                foreach (var filter in filters)
                {
                    _container.BuildUp(filter.Instance);
                    yield return filter;
                }
            }
        }
    }
