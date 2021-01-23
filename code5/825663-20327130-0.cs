    var query = teachers.GroupBy(t => new { t.SchoolBoardName, t.SchoolName });
    
    foreach(var schoolGroup in query)
    {
       Console.WriteLine(schoolGroup.Key.SchoolBoardName);
       Console.WriteLine(schoolGroup.Key.SchoolName);
    
       foreach(var teacher in schoolGroup)
            Console.WriteLine(teacher.TeacherName);
    }
        
                 
