    public class ProfileRequiredActionFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            public bool checkFilledProfile() {
                return CheckFilledProfile("FirstName", "LastName", "Country", "State", "City", "Address", "PostalCode", "Phone", "Mobile", "Email");
            }
    
            private static bool CheckFilledProfile(params string[] properties) {
                bool returnValue = true;
                for (int i = 0; i < properties.Length; i++)
                    if (string.IsNullOrEmpty(HttpContext.Current.Profile.GetPropertyValue(properties[i]) as string))
                       filterContext.Result = new RedirectResult("Path-To-Create-A-Profile");
                }
        }
    }
