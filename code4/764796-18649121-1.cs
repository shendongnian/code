    public static void PutLastName(ref Student student)
    {
        student = new Student();
        student.FirstName = "Simon";
        student.LastName = "Whitehead";
    }
    // .. calling code ..
    Student st = new Student();
    st.FirstName = "Marc";
    st.LastName = "Anthony";
    PutLastName(ref st);
    Console.WriteLLine(st.FirstName + " " + st.LastName); // "Simon Whitehead"
