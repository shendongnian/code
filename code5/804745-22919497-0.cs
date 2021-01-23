    class SecuredClass
    {
        public SecuredClass()
        {
            ClaimsPrincipalPermission.CheckAccess("SecuredClass", "GeneralAccess");
        }
        [ClaimsPrincipalPermission(SecurityAction.Demand, Resource = "MethodLevelSecuredMethod", Operation = "Call")]
        public void MethodLevelSecuredMethod()
        {
            Console.WriteLine("Called MethodLevelSecuredMethod");
        }
    }
