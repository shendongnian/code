    class Student
    {
       string Name { get; set; }
       Gender Sex { get; set; } // write an enum for this
       IEnumerable<Course> CoursesTaken { get; set; }
    }
    class Course
    {
       string Title { get; set; }
       Subject Subject { get; set; }
    }
    class Subject
    {
       string Name { get; set; }
       string Description { get; set; }
       double Points { get; set; }
    }
