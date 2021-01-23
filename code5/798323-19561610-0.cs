    public IList<IProject> GetSearchedProjects(string searchString)
    {
        foreach (var proj in _projects)
        {
            if (!searchProjects.Contains(proj))
                continue;
            StringBuilder sb = new StringBuilder();
            sb.Append("|").Append(proj.ProjectName);
            sb.Append("|").Append(proj.Country);
            sb.Append("|").Append(proj.CreatedBy);
            sb.Append("|").Append(proj.UploadDate.ToString());
    
            if (sb.ToString().Contains("|" + searchString))
                searchProjects.Add(proj);
        }
        return searchProjects;
    }
