    var roles = new[] { "Employee", "Manager" };
    var predicate = new StringBuilder();
    for (var i = 0; i < roles.Length; i++)
    {
        string role = roles[i];
        predicate.AppendFormat("Role = @{0}", i);
        if (i < roles.Length) predicate.Append(" OR ");
    }
    
    People.Where(predicate.ToString(), role.Cast<object>().ToArray());
