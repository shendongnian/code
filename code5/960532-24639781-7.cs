    public void UpdateDependencies(Project p, IEnumerable<Project> newDependencies)
    {
        var addDependencies = newDependencies.Except(p.Dependencies);
        var delDependencies = p.Dependencies.Except(newDependencies);
        foreach (var dependency in addDependencies)
        {
            p.Dependencies.Add(dependency);
        }
        foreach (var dependency in delDependencies)
        {
            p.Dependencies.Remove(dependency);
        }
    }
