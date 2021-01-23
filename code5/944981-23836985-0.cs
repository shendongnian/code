    [Serializable]
    public class SecureAttribute : OnMethodBoundaryAspect
    {
        public override void OnEntry(MethodExecutionArgs args)
        {
            bool UserLoggedIn = false; // get from DB
    
            if (!UserLoggedIn)
            {
                HttpContext.Current.Response.Redirect("/login");
            }
        }
    }
