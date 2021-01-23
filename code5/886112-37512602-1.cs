    namespace System.Web.Mvc
    {
        public static class MvcExtentions
        {
            /// <summary>
            /// Generates a fully qualified URL to an action method by using the specified action Name.
            /// </summary>
            /// <param name="sender">used for the generate the logic</param>
            /// <param name="actionName">an enum that will be used to generate the name from</param>
            /// <returns>a fully qualified url to the action in the current controller</returns>
            public static string Action(this UrlHelper sender, Enum actionName)
            {
                return sender.Action(actionName.ToString());
            }
        }
    }
