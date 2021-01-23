    public ActionResult Preregister(FormCollection fc)
    {
        bool fac = fc["Faculty"];
        bool stud = fc["Student"];
        if (stud == true)
        {
            return StudentRegister();
        }
        else if(fac == true)
        {
            return FacultyRegister();
        }
        else
        {
            return Index();
        }
    }
