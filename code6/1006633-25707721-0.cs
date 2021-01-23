    container.RegisterType<IRepositoryRole, RoleRepository>();
    public interface IRepositoryRole : IRepository<RoleMaster> 
    {
        public void DoCustomRoleWork(...) { ... }
    }
