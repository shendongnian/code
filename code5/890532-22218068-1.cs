    public class ApplicationRoleDTO : IRole
    {
        public ApplicationRoleDTO()
        {
            Id = Guid.NewGuid().ToString();
        }
    
        public ApplicationRoleDTO(string roleName)
            : this()
        {
            Name = roleName;
        }
        public string Id { get; set; }
        public string Name { get; set; }
        public Guid EnterpriseId { get; set; }
    }
