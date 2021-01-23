    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class NameToRouteDataAttribute : ActionNameSelectorAttribute
    {
        /// <Summary>Name of the Value you want to grab from the control.</Summary>
        public string Name { get; set; }
    
        public override bool IsValidName(ControllerContext controllerContext, string actionName, MethodInfo methodInfo)
        {
            ValueProviderCollection providers = controllerContext.Controller.ValueProvider as ValueProviderCollection;
    
            if (providers != null)
            {
                // We need this value-Provider as it contains the Data from the Form
                JQueryFormValueProvider formProvider = providers.OfType<JQueryFormValueProvider>().FirstOrDefault();
                if (formProvider != null)
                {
                    // now look for the specified value-prefix.
                    var kvp = formProvider.GetKeysFromPrefix(Name).FirstOrDefault();
                    if (kvp.Key != null)
                        controllerContext.Controller.ControllerContext.RouteData.Values[Name] = kvp.Key;
                }
            }
            return true;
        }
    }
