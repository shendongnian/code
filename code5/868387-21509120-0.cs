    public static IQueryable<T> Filter<T>(this IQueryable<T> source, Expression<Func<T, Employee>> employeeSelector, EmployeeFilter filter)
    {
        source = source.AsExpandable();
        if (!string.IsNullOrEmpty(filter.Gender))
            source = source.Where(e => employeeSelector.Compile().Invoke(e).Gender == filter.Gender);
        if (!string.IsNullOrEmpty(filter.NationalityID))
            source = source.Where(e => employeeSelector.Compile().Invoke(e).NationalityID == filter.NationalityID);
        // filter the group
        if (filter.IncludeChildGroups)
        {
            var groups = Security.GetAllChildGroups(filter.GroupID);
            source = source.Where(e => employeeSelector.Compile().Invoke(e).EmployeeGroupID.HasValue
                && groups.Contains(employeeSelector.Compile().Invoke(e).EmployeeGroupID.Value));
        }
        else
        {
            source = source.Where(e => employeeSelector.Compile().Invoke(e).EmployeeGroupID == filter.GroupID);
        }
        // filter status
        if (filter.OnlyActiveEmployees)
            source = source.Where(e => employeeSelector.Compile().Invoke(e).Status == "Active");
        return source;
    }
