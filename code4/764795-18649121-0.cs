    public static void PutLastName(Student student)
    {
        student = new Student();
        student.LastName = "Whitehead";
    }
    // .. calling code ..
    Student st = new Student();
    st.FirstName = "Marc";
    st.LastName = "Anthony";
    PutLastName(st);
    Console.WriteLLine(st.FirstName + " " + st.LastName); // "Marc Anthony"
