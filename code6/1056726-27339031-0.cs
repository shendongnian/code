    public class CourseVM
    {
      public string Name { get; set; }
      public IEnumerable<EnrollmentVM> Enrollments { get; set; }
    }
    public class EnrollmentVM
    {
      public int ID { get; set; }
      public string Title { get; set; }
      [DisplayFormat(DataFormatString="{0:0.00}")]
      public decimal Grade { get; set }
      public string LastName { get; set; }
      public bool CanDelete { get; set; }
      public string ClassName { get; set; }
    }
