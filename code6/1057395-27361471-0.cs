    public static class IPermissionExtensions
    {
        public static bool TryDemand(this IPermission permission)
        {
            try
            {
                permission.Demand();
            }
            catch (SecurityException e)
            {
                return false;
            }
            return true;
        }
    }
