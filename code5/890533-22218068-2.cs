    public class ApplicationRoleStore : IRoleStore<ApplicationRoleDTO>
    {
        private PayrollDBEntities _context;
        public ApplicationRoleStore() { }
    
        public ApplicationRoleStore(PayrollDBEntities database)
        {
            _context = database;
        }
    
        public Task CreateAsync(ApplicationRoleDTO role)
        {
            if (role == null)
            {
                throw new ArgumentNullException("RoleIsRequired");
            }
            var roleEntity = ConvertApplicationRoleDTOToAspNetRole(role);
            _context.AspNetRoles.Add(roleEntity);
            return _context.SaveChangesAsync();
            
        }
    
        public Task DeleteAsync(ApplicationRoleDTO role)
        {
            var roleEntity = _context.AspNetRoles.FirstOrDefault(x => x.Id == role.Id);
            if (roleEntity == null) throw new InvalidOperationException("No such role exists!");
            _context.AspNetRoles.Remove(roleEntity);
            return _context.SaveChangesAsync();
        }
    
        public Task<ApplicationRoleDTO> FindByIdAsync(string roleId)
        {
            var role = _context.AspNetRoles.FirstOrDefault(x => x.Id == roleId);
    
            var result = role == null
                ? null
                : ConvertAspNetRoleToApplicationRoleDTO(role);
    
            return Task.FromResult(result);
        }
    
        public Task<ApplicationRoleDTO> FindByNameAsync(string roleName)
        {
         
            var role = _context.AspNetRoles.FirstOrDefault(x => x.Name == roleName);
    
            var result = role == null
                ? null
                : ConvertAspNetRoleToApplicationRoleDTO(role);
    
            return Task.FromResult(result);
        }
    
        public Task UpdateAsync(ApplicationRoleDTO role)
        {
    
            return _context.SaveChangesAsync();
        }
    
        public void Dispose()
        {
            _context.Dispose();
        }
        private ApplicationRoleDTO ConvertAspNetRoleToApplicationRoleDTO(AspNetRole aspRole)
        {
            return new ApplicationRoleDTO{
                Id = aspRole.Id,
                EnterpriseId = aspRole.EnterpriseId,
                Name = aspRole.Name
            };
        }
    
        private AspNetRole ConvertApplicationRoleDTOToAspNetRole(ApplicationRoleDTO appRole)
        {
            return new AspNetRole{
                Id = appRole.Id,
                EnterpriseId = appRole.EnterpriseId,
                Name = appRole.Name,
            };
        }
    }
