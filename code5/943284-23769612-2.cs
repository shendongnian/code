    ...
    Session["Teacher"] = "456XYZ";
    Application.Lock();
 
    int countSession = (int)Application["StudentSessionCount"];
    Application["StudentSessionCount"] = countSession + 1;
 
    Application.UnLock();
    ... 
    protected void Session_End(object sender, EventArgs e)
    {
        string key = null;
        if (Session["Teacher"] != null)
          key = "TeacherSessionCount";
        else if (Session["Student"] != null)
          key = "StudentSessionCount";
    
        if (key != null)
        {
          Application.Lock();
     
          int countSession = (int)Application[key];
          Application[key] = countSession - 1;
     
          Application.UnLock();
        }
    }
