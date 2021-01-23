    class FullEmployeeMapper : IMapToNew<Employee, FullEmployee>
    {
        private List<FullRole> _roles = new List<FullRole>();
        public FullEmployee Map(Employee source)
        {
            FullEmployee employee = new FullEmployee()
            {
                Id = source.Id,
                Age = source.Age,
                BirthDate = source.BirthDate,
                Name = source.Name
            };
    
            var mapper = new FullRoleMapper();
            var client = new RedisClient("localhost");
    
            employee.Roles = _roles.Where(r => source.Roles.Contains(r.Id)).ToList();
            if (employee.Roles.Count != source.Roles.Count)
            {
                var newRoles = client
                    .As<Role>()
                    .GetByIds(source.Roles.Except(employee.Roles.Select(r => r.Id)))
                    .Select(r => mapper.Map(r)))
                    .ToList();
                employee.Roles.AddRange(newRoles);
                _roles.AddRange(newRoles);
            }
            return employee;
        }
    }
