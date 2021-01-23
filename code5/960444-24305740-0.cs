    public class AppPrincipal : IPrincipal
    {
       public bool IsInRole(string role)
       {
            return HttpContext.Current.User.IsInRole(role);
       }
       //other properties
    }
