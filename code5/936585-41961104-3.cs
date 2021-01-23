    public class ErrorController : Controller
    {
        private static readonly List<string> UrlNotContains = new List<string>{ "images/" };
        // GET: Error
        public ActionResult PageNotFound(string url)
        {
            if (url == null)
                return HttpNotFound();
            
            var routes = System.Web.Routing.RouteTable.Routes; /* Get routes */
            foreach (var route in routes.Take(routes.Count - 3).Skip(2)) /* iterate excluding 2 firsts and 3 lasts (in my case) */
            {
                var r = (Route)route;
                // Replace parameters by regex catch groups
                var pattern = Regex.Replace(r.Url, @"{[^{}]*}", c =>
                {
                    var parameterName = c.Value.Substring(1, c.Value.Length - 2);
                    // If parameter's constaint is a string, use it as the body
                    var body = r.Constraints.ContainsKey(parameterName) && r.Constraints[parameterName] is string
                            ? r.Constraints[parameterName]
                            : @".+";
                    return $@"(?<{parameterName}>{body})";
                });
                // Test regex !
                var regex = new Regex(pattern);
                Match match = regex.Match(url);
                if (!match.Success)
                    continue;
                // If match, call the controller
                var controllerName = r.Defaults["controller"].ToString();
                var actionName = r.Defaults["action"].ToString();
                var parameters = new Dictionary<string, object>();
                foreach(var groupName in regex.GetGroupNames().Skip(1)) /* parameters are the groups catched by the regex */
                    parameters.Add(groupName, match.Groups[groupName].Value);
                return Run(controllerName, actionName, parameters);
            }
            return HttpNotFound();
        }
        private ActionResult Run(string controllerName, string actionName, Dictionary<string, object> parameters)
        {
            // get the controller
            var ctrlFactory = ControllerBuilder.Current.GetControllerFactory();
            var ctrl = ctrlFactory.CreateController(this.Request.RequestContext, controllerName) as Controller;
            var ctrlContext = new ControllerContext(this.Request.RequestContext, ctrl);
            var ctrlDesc = new ReflectedControllerDescriptor(ctrl.GetType());
            // get the action
            var actionDesc = ctrlDesc.FindAction(ctrlContext, actionName);
            // Change the route data so the good default view will be called in time
            foreach (var parameter in parameters)
                if (!ctrlContext.RouteData.Values.ContainsKey(parameter.Key))
                    ctrlContext.RouteData.Values.Add(parameter.Key, parameter.Value);
            ctrlContext.RouteData.Values["controller"] = controllerName;
            ctrlContext.RouteData.Values["action"] = actionName;
            // To call the action in the controller, the parameter dictionary needs to have a value for each parameter, even the one with a default
            var actionParameters = actionDesc.GetParameters();
            foreach (var actionParameter in actionParameters)
            {
                if (parameters.ContainsKey(actionParameter.ParameterName)) /* If we already have a value for the parameter, change it's type */
                    parameters[actionParameter.ParameterName] = Convert.ChangeType(parameters[actionParameter.ParameterName], actionParameter.ParameterType);
                else if (actionParameter.DefaultValue != null) /* If we have no value for it but it has a default value, use it */
                    parameters[actionParameter.ParameterName] = actionParameter.DefaultValue;
                else if (actionParameter.ParameterType.IsClass) /* If the expected parameter is a class (like a ViewModel) */
                {
                    var obj = Activator.CreateInstance(actionParameter.ParameterType); /* Instanciate it */
                    foreach (var propertyInfo in actionParameter.ParameterType.GetProperties()) /* Feed the properties */
                    {
                        // Get the property alias (If you have a custom model binding, otherwise, juste use propertyInfo.Name)
                        var aliasName = (propertyInfo.GetCustomAttributes(typeof(BindAliasAttribute), true).FirstOrDefault() as BindAliasAttribute)?.Alias ?? propertyInfo.Name;
                        var matchingKey = parameters.Keys.FirstOrDefault(k => k.Equals(aliasName, StringComparison.OrdinalIgnoreCase));
                        if (matchingKey != null)
                            propertyInfo.SetValue(obj, Convert.ChangeType(parameters[matchingKey], propertyInfo.PropertyType));
                    }
                    parameters[actionParameter.ParameterName] = obj;
                }
                else /* Parameter missing to call the action! */
                    return HttpNotFound();
            }
            // Set culture on the thread (Because my BaseController.BeginExecuteCore won't be called)
            CultureHelper.SetImplementedCulture();
            // Return the other action result as the current action result
            return actionDesc.Execute(ctrlContext, parameters) as ActionResult;
        }
    }
