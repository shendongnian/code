    public class Instructor
    {
      public InstructorTypesEnum Type { get; set; }
      [InverseProperty("Instructors")]
      public virtual ICollection<Course> Courses { get; set; }
      [InverseProperty("Coinstructors")]
      public virtual ICollection<Course> CoInstructingCourses { get; set; }
    }
