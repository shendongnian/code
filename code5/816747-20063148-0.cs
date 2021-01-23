    if(user.Role == "Student")
    {  
       Response.Redirect("Student.aspx");
    }
    else if(user.Role == "Admin")
    {  
       Response.Redirect("Admin.aspx");
    }
