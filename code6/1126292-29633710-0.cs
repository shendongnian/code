    private IQueryable<Employee> EmployeesByOrganizationLevel(IQueryable<Employee> employees, int orgEntityId)
        {
            var results = new List<Employee>();
            foreach (var employee in employees)
            {
                if (this.FindOrganization(employee.OrganizationEntity, orgEntityId))
                {
                    results.Add(employee);
                }    
            }
            return results.AsQueryable();
        }
        private bool FindOrganization(OrganizationEntity entity, int orgEntityId)
        {
            if (entity == null)
            {
                return false;
            }
            else if (entity.Id == orgEntityId)
            {
                return true;
            }
            else
            {
                return this.FindOrganization(entity.Parent, orgEntityId);
            }
        }
