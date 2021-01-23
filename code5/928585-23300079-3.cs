    [IdentityImpersonate]    
    public Task<int> CountMyJobsAsync(object parameterName, string name)
    {
        //JobRepository is effectively a DbSet<Job> and this call returns IQueryable<Job>
        return _jobRepository.Where(i => i.Name == name).CountAsync();  
    }
