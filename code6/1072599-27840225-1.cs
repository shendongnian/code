    public class PermissionAuthAttribute : AuthorizeAttribute
    {
        private readonly List<string> _accessLevels;
        public PermissionAuth(params string[] accessLevels)
        {
             _accessLevels = accessLevels.ToList();
        }
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            if (!base.IsAuthorized(actionContext))
            {
                return false;
            }
            int staffID = (User as CustomPrincipal).UserId;
            int siteId = Functions.GetSiteIdFromCookie();
            if (Functions.UserHasAccess(staffID, AccessLevels.access_StudentDetailsUpdate,siteId) == true) { 
                return true;
            }
            else {
                return false
            };
        }
    }
