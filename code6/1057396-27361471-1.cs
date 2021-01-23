    public class PermissionManager
    {
        private Dictionary<IPermission, bool> permissions;
        public PermissionManager(IEnumerable<IPermission> permissions)
        {
            foreach (var permission in permissions)
            {
                this.permissions.Add(permission, permission.TryDemand());
            }
        }
        public bool HasPermission(IPermission permission)
        {
            bool value;
            if (permissions.TryGetValue(permission, out value))
                return value;
            else
                return false;
        }
    }
