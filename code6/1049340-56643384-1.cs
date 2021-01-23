    public class Project
    {
        public long ID { get; set; }
        public string Name { get; set; }
    
        // explicit constraint is required to resolve child-dependent relationship
        [ForeignKey("BacklogId")]
        public virtual Sprint Backlog { get; set; }
    }
    
    public class Sprint
    {
        public long ID { get; set; }
        public string Name { get; set; }
    
        // explicit constraint is required to resolve child-dependent relationship
        [ForeignKey("ProjectId")]
        public virtual Project Project { get; set; }
    }
    
    var project = new Project { Name = "Some project" };
    // intermediate saving is required to avoid circular dependency exception
    context.Projects.Add(project);
    context.SaveChanges();
    
    var backlog = new Sprint { Name = "Backlog sprint", Project = project };
    project.Backlog = backlog;
    context.Sprints.Add(backlog);
    context.SaveChanges();
