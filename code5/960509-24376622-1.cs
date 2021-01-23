        public void UpdateDependencies(Project p, List<int> newDependencyIds)
        {
            p.Dependencies.RemoveAll(d => !newDependencyIds.Contains(d.Dependency.Id));
            var toAdd = newDependencyIds.Select(d => p.Dependencies.Any(pd => pd.Dependency.Id != d)).ToList();
            toAdd.ForEach(dependencyId => p.Dependencies.Add(new ProjectDependency{Project = p, Dependency = GetDependency(dependencyId)}));
        }
