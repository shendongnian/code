    public class PermissionCheckAttribute: ActionFilterAttribute
    {
       public Permissions Permissions {get;set;}
       public PermissionCheck(Permissions permissions)
       {
               Permissions = permissions;
       }
    }
