    // from the Main's point of view, this function does absolutely nothing
    public static PutLastName(Student student)
    {
        student = new Student();
    }
    // This would clear Main's student.
    public static PutLastName(ref Student student)
    {
        student = new Student();
    }
