    public void Delete(Project project)
    {
        using (var txn = _session.BeginTransaction())
        {
            project.ProjectDependencies.Clear();
            project.DependentDependentOf.Clear();
            _session.Delete(project);
            txn.Commit();
        }
    }
