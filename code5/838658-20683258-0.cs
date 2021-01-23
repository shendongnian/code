    public static class MyExtensions
    {
    
        public static string MyButton(this HtmlHelper helper, string name, 
                                  string actionName, string controllerName)
        {
            return @"<a href='/" + controllerName + "/" + actionName + " >" +
                       name + "</a>";
        }     
    }
