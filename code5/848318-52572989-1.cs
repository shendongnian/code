    public async Task<Project> GetProjectAsync(string name) 
    {
        DBContext _localdb = new DBContext();
        return await _localdb.Projects.FirstOrDefaultAsync(x => x.Name == name);
    }
