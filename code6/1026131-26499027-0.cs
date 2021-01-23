     public class Course
        {
            public int CourseId { get; set; }
            public string CourseNumber { get; set; }
            public string CourseName { get; set; }
            public decimal Credits { get; set; }
            public bool? PreReq { get; set; }
            public int DepartmentID { get; set; }
            
            public int? PreRequisiteForCourseId {get; set;}
            public virtual Course PreRequisiteForCourse {get; set;}
            [InverseProperty("PreRequisiteForCourse")]
            public virtual ICollection<Course> PreReq { get; set; }
        }
