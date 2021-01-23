    protected void Application_Start(object sender, EventArgs e)
    {
        //Session Count is intialized with 0.      
        Application["TeacherSessionCount"] = 0;
        Application["StudentSessionCount"] = 0;
    }
