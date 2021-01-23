    public class AddUserRoleVM
    {
        public string UserName { set; get; }
        public List<UserRoleVM> Roles { set; get; }
        public AddUserRoleVM()
        {
            Roles=new List<UserRoleVM>();
        }
    }
    public class UserRoleVM
    {
        public int RoleId { set; get; }
        public String RoleName { set; get; }
        public bool IsSelected { set; get; }
    }
