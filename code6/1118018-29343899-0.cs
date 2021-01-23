    public class ProjectInformation {
      public int ProjectID { get; set; }
      public virtual ICollection<ProjectUpdate> ProjectUpdates { get; set; }
    }
    
    db.Project
      .Select(p => new {
        ProjectID = p.ProjectID,
        MostRecentProjectUpdate = p.ProjectUpdates.OrderByDescending(u => u.CreateDate).FirstOrDefault()
    });
