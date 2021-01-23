    public class AssignCourseVM
    {
      public int StudentID { set;get;}
      public string StudentName { set;get;}
      public List<CourseRegistration> Courses { set;get;}
      public AssignCourseVM()
      {
        Courses =new List<CourseRegistration>();
      }
    }
    public class CourseRegistration
    {
      public int CourseID { set;get;}
      public string CourseName { set;get;}
      public bool IsRegistered { set;get;}
    }
