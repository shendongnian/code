    using (var transaction = context.Database.BeginTransaction())
    {
        try
        {
            var project = new Project { Name = "Project 1" };
            context.Projects.Add(project);
            context.SaveChanges();
            var backlog = new Sprint { Name = "Backlog", Project = project };
            project.Backlog = backlog;
            context.Sprints.Add(backlog);
            context.SaveChanges();
            transaction.Commit();
        }
        catch (Exception)
        {
            transaction.Rollback();
            throw;
        }
    }
