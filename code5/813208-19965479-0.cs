    class Student {
     public int StudentId {get; set;}
    }
    
    class Class {
     public int ClassId {get; set;}
    }
    
    class Course {
     public int CourseId {get; set;}
    }
    
    class ClassCourse {
     public int ClassCourseId {get; set;}
     public int ClassId {get; set;}
     public int CourseId {get; set;}
    }
