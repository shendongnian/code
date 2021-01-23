    public void ReferenceLoop_CheckAreEqual()
    {
        Student student = new Student();
        Course course = new Course();
    
        student.Course = course;
        course.Student = student;
        //This is now allowed
        course.Student.Course.Student.Course;
        Assert.IsTrue(Object.ReferenceEquals(course, course.Student.Course.Student.Course);
    }
