    public class Course
    {
    public int CourseId { get; set; }
    public string Name { get; set; }
    public string InstitutionCode { get; set; }     
    public string Description { get; set; }
    public bool IsElective { get; set; }
    //nav elements
    public virtual ICollection<Instructor> Instructors { get; set; }
    public virtual ICollection<Student> Students { get; set; }
    public virtual ICollection<Module> Modules { get; set; }
    public virtual ICollection<PreReqCourse> Prerequisites { get; set; }
    // You can Find follow on courses, by accessing PreReqCourse table, but if you felt this navigation offered enough value, create a post req table too. Using same approach.
    // public virtual ICollection<Course> Postrequisites { get; set; } 
    }
    public class PreReqCourse
    {
    public virtual int Id {get; set;}
    public virtual int CourseId { get; set; }
    public virtual Course  PreReqForCourse { get; set; } //Nav prop
    }
    modelBuilder.Entity<Course>()
                .HasMany(e => e.Prerequisites)
                .WithMany();   
    // Leave WithMany empty. You can define in PreReqCourse Table model, you dont need to model from both directions. 
    modelBuilder.Entity<PreReqCourse>()
                .HasRequired(e => e.PreReqForCourse)
                .HasForeignKey(f => f.CourseId)
                .WithMany(p=>p.PreRequisites);
             
