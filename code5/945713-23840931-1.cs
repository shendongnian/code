    public class Project
    {
       [Key]
       public int ProjectId { get; set; }
       public string Name { get; set; }
       // Foreign Key - Project lead (Person)
       public int ProjectLeadId { get; set; }
       public virtual Person ProjectLead { get; set; }
       // Create many to many relationship with People - Team members on this project
       public virtual ICollection<ProjectPerson> ProjectPeople { get; set; }
       public Project()
       {
           ProjectPerson = new HashSet<ProjectPerson>();
       }
