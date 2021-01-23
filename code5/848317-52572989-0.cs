    public async Task&lt;Project&gt; GetProjectAsync(string name)
    
    {
    
     DBContext _localdb = new DBContext();
    
     return await _localdb.Projects.FirstOrDefaultAsync(x =&gt; x.Name == name);
    
    }
