    public void UpdateDependencies(Project p, List<int> newDependencyIds)
    {
        var newDependencies = newDependencyIds.Select(d => new ProjectDependency{ Project = p, Dependency = GetDependency(d) });
            
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
