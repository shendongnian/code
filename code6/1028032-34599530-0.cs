    /// <summary>
    /// Allows for exclusion from attribute routing of controllers based on name
    /// </summary>
    public class ExcludeByControllerNameRouteProvider : DefaultDirectRouteProvider {
        private string _exclude;
        /// <summary>
        /// Pass in the string value that you want to exclude, matches on "ControllerType.FullName" and "ControllerType.BaseType.FullName"
        /// </summary>
        /// <param name="exclude"></param>
        public ExcludeByControllerNameRouteProvider(string exclude) {
            _exclude = exclude;
        }
        protected override IReadOnlyList<RouteEntry> GetActionDirectRoutes(
        HttpActionDescriptor actionDescriptor,
        IReadOnlyList<IDirectRouteFactory> factories,
        IInlineConstraintResolver constraintResolver)
        {
            var actionRoutes = new List<RouteEntry>();
            var currentController = actionDescriptor.ControllerDescriptor.ControllerType;
            if (!currentController.FullName.Contains(_exclude) && !currentController.BaseType.FullName.Contains(_exclude))
            {
                var result = base.GetActionDirectRoutes(actionDescriptor, factories, constraintResolver);
                actionRoutes = new List<RouteEntry>(result);
            }
            return actionRoutes.AsReadOnly();
        }
    }
