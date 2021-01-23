    public IEnumrable<Project> pullAllProjects
    {
        .
        .
        .
        var projects = new List<Project>();
        while (rdr.Read())
        {
            projects.Add(new Project 
            {
                Id = (int)rdr["project_id"];
                Name = (string)rdr["project_name"];
                Title = (string)rdr["project_title"];
                Network = (int)rdr["main_network"];
                Start = (DateTime)rdr["project_start"];
             });
        }
        return projects;
    }
