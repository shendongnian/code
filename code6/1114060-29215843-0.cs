    private static string GetAllControllersAsRegex() 
            { 
                var controllers = typeof(MvcApplication).Assembly.GetTypes()
                    .Where(t => t.IsSubclassOf(typeof(Controller))); 
    
                var controllerNames = controllers
                    .Select(c => c.Name.Replace("Controller", "")); 
    
                return string.Format("({0})", string.Join("|", controllerNames)); 
            }
