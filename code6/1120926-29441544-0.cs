    foreach (var item in ViewBag.Courses)
    {
        <h2> item.CourseName <h2>
        item.Projects = item.Projects.OrderBy(project => project.vote_amount).toList(); 
               
        foreach (var project in item.Projects)
        { 
             <h2> project.Name <h2>
        }
    }
