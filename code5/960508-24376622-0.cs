        public void UpdateDependencies(Project p, List<int> newDependencyIds)
        {
            p.Dependencies.RemoveAll(d => !newDependencyIds.Contains(d.Dependency.Id));
            var toAdd = newDependencyIds.Select(d => p.Dependencies.Any(pd => pd.Dependency.Id != d)).ToList();
            toAdd.ForEach(p.Dependencies.Add(dependencyId => new ProjectDependency{Project = p, Dependency = GetDependency(dependencyId)}));
        }
