    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class RequiresAssignedAccess : AuthorizeAttribute
    {
        public int AccessType { get; private set; }
        public int IdType { get; private set; }
        public int IdValue { get; private set; }
        public int Level { get; private set; }
        public RequiresAssignedAccess(int accessType, int idType, int idValue, int level)
        {
            ...
        }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (!base.AuthorizeCore(httpContext))
                return false;
            bool retval = ...
            return retval;
        }
    }
