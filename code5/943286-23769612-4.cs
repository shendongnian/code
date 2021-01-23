    ...
    Session["Teacher"] = "123ABC";
    Application.Lock();
 
    int countSession = (int)Application["TeacherSessionCount"];
    Application["TeacherSessionCount"] = countSession + 1;
 
    Application.UnLock();
    ... 
