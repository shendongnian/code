    [AutoMapFrom(typeof(User))]
    public class UserListDto
    {
        public string Name { get; set; }
      
        public IList<UserRoleOutput> Roles { get; set; }
        [AutoMapFrom(typeof(UserRole))]
        public class UserRoleOutput
        {
            public int RoleId { get; set; }
        }
    }
