    public static IEnumerable<Employee> AllEmployees(Employee root)
    {
        if (root == null)
            yield break;
        yield return root;
        if (root.ChildOrg == null)
            yield break;
        foreach (var child in root.ChildOrg.SelectMany(AllEmployees))
            yield return child;
    }
